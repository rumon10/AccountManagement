using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
namespace AccountManagement
{
    /// <summary>
    /// Interaction logic for AccountRegistration.xaml
    /// </summary>
    public partial class AccountRegistration : Window
    {
         MessageBoxUser _message = new  MessageBoxUser();
         Boolean _isCreatedNew  = false ;
         Boolean _isSavedRecord = false ;
         int  _accountId = 0;
         DataTable  _AccountList = new  DataTable();
         int _recordCount = 1;

        public AccountRegistration()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void setEnumValyes()
        {
            this.SetToolBarPermission();
            ddlAccountType.ItemsSource = Enum.GetValues(typeof(Role));
            ddlAccountType.SelectedIndex = 0;
            this.SetAccessLevel();
        }
        private void SetToolBarPermission()
        {
            try
            {
                AccountInformation accounts = new AccountInformation();
                string accountType = accounts.GetAccountType();
                if (accountType == Role.Admin.ToString())
                {
                    btnCreate.IsEnabled = true;
                    btnSaveT.IsEnabled = true;
                    btnDeleteT.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                    btnBack.IsEnabled = true;
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    btnExportT.IsEnabled = true;
                    btnSearch.IsEnabled = true;
                }
                else
                {
                    btnCreate.IsEnabled = false;
                    btnSaveT.IsEnabled = false;
                    btnDeleteT.IsEnabled = false;
                    btnFirst.IsEnabled = false;
                    btnBack.IsEnabled = false;
                    btnNext.IsEnabled = false;
                    btnLast.IsEnabled = false;
                    btnExportT.IsEnabled = false;
                    btnSearch.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX (ex.Message, "Error", 1, 4);
            }
        }
        private void SetAccessLevel()
        {
            ddlAccessLevel.Items.Add(0);
            ddlAccessLevel.Items.Add(1);
            ddlAccessLevel.Items.Add(2);
            ddlAccessLevel.Items.Add(3);
            ddlAccessLevel.Items.Add(4);
            ddlAccessLevel.SelectedIndex = 0;
        }
        private void ResetAllText()
        {
            txtAccountName.IsReadOnly = false;
            txtAccountName.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtpassword.Password = string.Empty;
            ddlAccessLevel.SelectedIndex = 0;
            ddlAccountType.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setEnumValyes();
            LoadAccountInfo();
        }

        private void SaveAccountInformation()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountName.Text) == true)
                {
                    _message.ShowMessageBOX("Account Name is required. Please enter the account Name.", "Account Name Required!", 1, 3);
                    txtAccountName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtpassword.Password.Trim()) == true)
                {
                    _message.ShowMessageBOX("Password is required. Please enter the Password.", "Password Required!", 1, 3);
                    txtpassword.Focus();
                    return;
                }
                AccountBO accountBO = new AccountBO();
                accountBO.AccessLevel = int.Parse(ddlAccessLevel.Text.Trim());
                accountBO.AccountName = txtAccountName.Text.Trim();
                accountBO.AccountType = ddlAccountType.Text.Trim();
                accountBO.FullName = txtFullName.Text.Trim();
                accountBO.Password = txtpassword.Password.Trim();

                AccountInformation accountBAL = new AccountInformation();

                if (_isCreatedNew == true)
                {
                    if (accountBAL.Isexists(accountBO.AccountName) == true)
                    {
                        _message.ShowMessageBOX("Account Name " + accountBO.AccountName + " has been already exists. Please enter the unique account name to identify each accounts.", "Unique Account Name Required!", 1, 3);
                        txtAccountName.Focus();
                        return;
                    }
                    else
                    {
                        accountBAL.addAccountInformation(accountBO);
                        txtAccountName.IsReadOnly = true;
                        _AccountList = accountBAL.GetAccountInfo();
                        _message.ShowMessageBOX("Account Name " + accountBO.AccountName + " is sucessfully created.", "Sucess", 1, 1);
                        _isSavedRecord = true;
                        _isCreatedNew = false;
                        return;
                    }
                }
                else if (_isSavedRecord == true)
                {
                    accountBAL.UpdateAccountInformation(accountBO);
                    _AccountList = accountBAL.GetAccountInfo();
                    _message.ShowMessageBOX("Account Name " + accountBO.AccountName + " is sucessfully updarted.", "Update", 1, 1);
                    _isCreatedNew = false;
                    _isSavedRecord = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }
        private void LoadAccountInfo()
        {
            try
            {
                AccountInformation accounts = new AccountInformation();
                if (accounts.GetAccountType() == Role.Admin.ToString())
                {
                    _AccountList = accounts.GetAccountInfo();
                }
                else
                {
                    _AccountList = accounts.GetAccountInfo(accounts.GetAccountId());
                }
                if (_AccountList.Rows.Count > 0)
                {
                    txtAccountName.Text = _AccountList.Rows[0]["AccountName"].ToString();
                    txtAccountName.IsReadOnly = true;
                    txtFullName.Text = _AccountList.Rows[0]["FullName"].ToString();
                    txtpassword.Password = _AccountList.Rows[0]["Password"].ToString();
                    ddlAccessLevel.Text = _AccountList.Rows[0]["AccessLevel"].ToString();
                    ddlAccountType.Text = _AccountList.Rows[0]["AccountType"].ToString();
                    _isCreatedNew = false;
                    _isSavedRecord = true;
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        private void DeleteAccountInfo()
        {
            try
            {
                if (txtAccountName.Text.Trim() != string.Empty)
                {
                    _message.ShowMessageBOX("Do you want to delete the account information of account name-" + txtAccountName.Text.Trim() + "?", "Delete Confirm", 2, 2);
                    if (_message._result == true)
                    {
                        AccountInformation accounts = new AccountInformation();
                        accounts.DeleteAccountInformation(txtAccountName.Text.Trim());
                        _AccountList = accounts.GetAccountInfo();
                        _message.ShowMessageBOX("Account name " + txtAccountName.Text.Trim() + " has been sucssfully removed.", "Delete Sucess", 1, 1);
                        this.ResetAllText();
                        _isCreatedNew = false;
                        _isSavedRecord = false;
                    }
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        
        private void excelExporting()
        {
            try
            {
                AccountInformation accounts = new AccountInformation();
                _AccountList = accounts.GetAccountInfo();

                if (_AccountList.Rows.Count <= 0)
                {
                    _message.ShowMessageBOX("No data exists for exporting into excel.", "Excel Export Log", 1, 1);
                    return;
                }

                Microsoft.Office.Interop.Excel.Application xlApp = default(Microsoft.Office.Interop.Excel.Application);
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = default(Microsoft.Office.Interop.Excel.Workbook);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = default(Microsoft.Office.Interop.Excel.Worksheet);
                object misValue = System.Reflection.Missing.Value;
                int i = 0;
                int j = 0;
                this.Cursor = Cursors.Wait;
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(1);
                xlWorkSheet = xlWorkBook.Worksheets [1];
                Microsoft.Office.Interop.Excel.Range rg = default(Microsoft.Office.Interop.Excel.Range);
                xlWorkSheet.Name = "Account Information";


                xlWorkSheet.Range["A1:O1"].Merge();
                xlWorkSheet.Range["A1:O1"].Value = "Account Information";
                xlWorkSheet.Range["A1:O1"].Font.Bold = true;
                xlWorkSheet.Range["A1:O1"].Font.Size = 16;
                xlWorkSheet.Range["A1:O1"].Font.Name = "Arial";
                xlWorkSheet.Range["A1:O1"].Style.HorizontalAlignment = -4108;

                for (i = 0; i <= _AccountList.Columns.Count - 1; i++)
                {
                    xlWorkSheet.Cells[2, i + 1] = _AccountList.Columns[i].ColumnName.ToString();
                    rg = xlWorkSheet.Cells[2, i + 1];
                    rg.EntireColumn.AutoFit();
                    rg.Font.Bold = true;
                }


                for (i = 0; i <= _AccountList.Rows.Count - 1; i++)
                {
                    for (j = 0; j <= _AccountList.Columns.Count - 1; j++)
                    {
                        if (_AccountList.Columns[j].ColumnName == "CreateDate")
                        {
                            rg = xlWorkSheet.Cells[i + 1 + 2, j + 1];
                            rg.NumberFormatLocal = "mm/dd/yyyy";
                            rg.HorizontalAlignment = -4152;
                            rg.Value2 = _AccountList.Rows[i][j].ToString();
                            rg.EntireColumn.AutoFit();
                        }
                        else
                        {
                            xlWorkSheet.Cells[i + 1 + 2, j + 1] = _AccountList.Rows[i][j].ToString();
                            rg.HorizontalAlignment = -4131;
                            rg = xlWorkSheet.Cells[i + 1 + 2, j + 1];
                            rg.EntireColumn.AutoFit();
                        }
                    }
                }
                xlApp.Visible = true;
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void displayRecordInformation(int Inx)
        {
            try
            {

                AccountInformation accounts = new AccountInformation();
                _AccountList = accounts.GetAccountInfo();

                if (Inx == -1)
                {
                    Inx = _AccountList.Rows.Count - 1;
                    _recordCount = Inx;
                }

                if (_AccountList.Rows.Count > 0 & Inx >= 0 & Inx <= _AccountList.Rows.Count - 1)
                {
                    txtAccountName.Text = _AccountList.Rows[Inx]["AccountName"].ToString();
                    txtAccountName.IsReadOnly = true;
                    txtFullName.Text = _AccountList.Rows[Inx]["FullName"].ToString();
                    txtpassword.Password = _AccountList.Rows[Inx]["Password"].ToString();
                    ddlAccessLevel.Text = _AccountList.Rows[Inx]["AccessLevel"].ToString();
                    ddlAccountType.Text = _AccountList.Rows[Inx]["AccountType"].ToString();
                    _isCreatedNew = false;
                    _isSavedRecord = true;
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        private void btnSaveT_Click_1(object sender, RoutedEventArgs e)
        {
            this.SaveAccountInformation();
        }

        private void btnCreate_Click_1(object sender, RoutedEventArgs e)
        {
            _isCreatedNew = true;
            this.ResetAllText();
        }

        private void btnDeleteT_Click_1(object sender, RoutedEventArgs e)
        {
            this.DeleteAccountInfo();
        }

        private void btnExportT_Click_1(object sender, RoutedEventArgs e)
        {
            this.excelExporting();
        }

        private void btnFirst_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                _recordCount = 0;
                this.displayRecordInformation(_recordCount);
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        private void btnNext_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_recordCount < _AccountList.Rows.Count)
                {
                    _recordCount = _recordCount + 1;
                    this.displayRecordInformation(_recordCount);
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        private void btnLast_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.displayRecordInformation(-1);
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_recordCount > 0)
                {
                    _recordCount = _recordCount - 1;
                    this.displayRecordInformation(_recordCount);
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string whereBy = " 0=0 ";
                if (txtAccountName.Text.Trim() != string.Empty)
                {
                    whereBy = whereBy + " AND AccountTable.AccountName='" + txtAccountName.Text.Trim() + "'";
                }

                if (txtFullName.Text.Trim() != string.Empty)
                {
                    whereBy = whereBy + " AND AccountTable.FullName='" + txtFullName.Text.Trim() + "'";
                }

                DisplayAccountInfo display = new DisplayAccountInfo();
                display._whereBy = whereBy;
                display.ShowDialog();

                if (string.IsNullOrEmpty(display._accountName) == false)
                {
                    string AccountName = display._accountName;
                    AccountInformation accounts = new AccountInformation();
                    DataTable data = accounts.MemberAccountInformation(AccountName);
                    if (data.Rows.Count > 0)
                    {
                        txtAccountName.Text = data.Rows[0]["AccountName"].ToString();
                        txtAccountName.IsReadOnly = true;
                        txtFullName.Text = data.Rows[0]["FullName"].ToString();
                        txtpassword.Password = data.Rows[0]["Password"].ToString();
                        ddlAccessLevel.Text = data.Rows[0]["AccessLevel"].ToString();
                        ddlAccountType.Text = data.Rows[0]["AccountType"].ToString();
                        _isCreatedNew = false;
                        _isSavedRecord = true;
                    }
                }

            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX(ex.Message, "Error", 1, 4);
            }
        }
    }
}
