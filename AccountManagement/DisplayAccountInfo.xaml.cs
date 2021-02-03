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

namespace AccountManagement
{
    /// <summary>
    /// Interaction logic for DisplayAccountInfo.xaml
    /// </summary>
    public partial class DisplayAccountInfo : Window
    {
        MessageBoxUser _message = new MessageBoxUser ();
        public string _whereBy = string.Empty ;
        public string _accountName = string.Empty ;
        public DisplayAccountInfo()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClosed_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadDgvInfo()
        {

            try
            {
                AccountInformation accounts = new AccountInformation();
                List<AccountBO> _accountBOList = new List<AccountBO>();
                _accountBOList = accounts.GetAccountInformationObject(_whereBy);
                Accountlist.ItemsSource = _accountBOList;

            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX (ex.Message, "Error", 1, 1);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDgvInfo();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true ;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnUpdateSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Accountlist.Items.Count > 0 & Accountlist.SelectedItems.Count >= 1)
                {
                    AccountBO dgvRow = default(AccountBO);
                    dgvRow = (AccountBO)Accountlist.SelectedItems[0]; 
                    _accountName = dgvRow.AccountName.ToString();
                    if (string.IsNullOrEmpty(_accountName) == true)
                    {
                        _message.ShowMessageBOX ("No Account is selected. Please select an account.", "Select", 1, 4);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    _message.ShowMessageBOX ("No Record is exists.", "No Record", 1, 4);
                    return;
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX (ex.Message, "Error", 1, 1);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Accountlist.Items.Count > 0)
                {
                    AccountBO dgvRow = default(AccountBO);
                    dgvRow = (AccountBO)Accountlist.SelectedItems[0];
                    _accountName = dgvRow.AccountName;
                    if (string.IsNullOrEmpty(_accountName) == true)
                    {
                        _message.ShowMessageBOX ("No Account is selected. Please select an account.", "Select", 1, 4);
                    }
                    else
                    {
                        _message.ShowMessageBOX ("Do you want to delete the account information of account name-" + _accountName + "?", "Delete Confirm", 2, 2);
                        if (_message._result == true)
                        {
                            AccountInformation accounts = new AccountInformation();
                            accounts.DeleteAccountInformation(_accountName);
                            _message.ShowMessageBOX ("Account name " + _accountName + " has been sucssfully removed.", "Delete Sucess", 1, 1);
                            _accountName = string.Empty;
                            this.LoadDgvInfo();
                        }
                    }
                }
                else
                {
                    _message.ShowMessageBOX ("No Record is exists.", "No Record", 1, 4);
                    return;
                }
            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX (ex.Message, "Error", 1, 1);
            }
        }
    }
}
