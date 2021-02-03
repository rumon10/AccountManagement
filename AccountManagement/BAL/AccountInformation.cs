using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace AccountManagement
{
    public class AccountInformation
    {
        public bool IsAunthenticatedUser(string user, string pass)
        {
            bool isactive = false;
            string query = "SELECT [AccountId],[AccountName],[FullName],[Password],[AccountType],[AccessLevel],[CreateDate],[CreatedBy]  FROM [AccountTable] WHERE [AccountName]='" + user + "' AND [Password]='" + pass + "'";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                DataTable datatable = dbConnection.ExecuteQuery(query);
                if (datatable.Rows.Count > 0)
                {
                    LoginInformationBO.accountName = datatable.Rows[0]["AccountName"].ToString();
                    LoginInformationBO.password = datatable.Rows[0]["Password"].ToString();
                    LoginInformationBO.accountId = int.Parse(datatable.Rows[0]["AccountId"].ToString());
                    LoginInformationBO.UserFullName = datatable.Rows[0]["FullName"].ToString();
                    LoginInformationBO.logindatetime = DateTime.Now;
                    LoginInformationBO.accountType = datatable.Rows[0]["AccountType"].ToString();
                    LoginInformationBO.accessLevel = int.Parse(datatable.Rows[0]["AccessLevel"].ToString());
                    isactive = true;
                }
                else
                {
                    isactive = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dbConnection.CloseDatabase();

            }

            return isactive;
        }
        public int GetAccountId()
        {
            return LoginInformationBO.accountId;
        }
        public string GetAccountName()
        {
            return LoginInformationBO.accountName;
        }
        public string GetAccountFullName()
        {
            return LoginInformationBO.UserFullName;
        }
        public string GetPassword()
        {
            return LoginInformationBO.password;
        }
        public string GetAccountType()
        {
            return LoginInformationBO.accountType;
        }
        public int GetAccessLewvel()
        {
            return LoginInformationBO.accessLevel;
        }
        public bool Isexists(string accountName)
        {
            bool isexist = false;
            string query = "SELECT * FROM AccountTable WHERE AccountName='" + accountName + "'";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                DataTable datatable = dbConnection.ExecuteQuery(query);
                if (datatable.Rows.Count > 0)
                {
                    isexist = true;
                }
                else
                {
                    isexist = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return isexist;
        }
        public object addAccountInformation(AccountBO accountInfo)
        {
            string query = "INSERT INTO AccountTable ([AccountName],[FullName],[Password],[AccountType],[AccessLevel],[CreateDate],[CreatedBy]) VALUES ('" + accountInfo.AccountName + "','" + accountInfo.FullName + "','" + accountInfo.Password + "','" + accountInfo.AccountType + "'," + accountInfo.AccessLevel + ",GETDATE()," + LoginInformationBO.accountId + ")";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                dbConnection.ExecuteNonQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return null;
        }
        public object UpdateAccountInformation(AccountBO accountInfo)
        {
            string query = "UPDATE AccountTable SET [FullName]='" + accountInfo.FullName + "',[Password]='" + accountInfo.Password + "',[AccountType]='" + accountInfo.AccountType + "',[AccessLevel]=" + accountInfo.AccessLevel + " WHERE AccountName='" + accountInfo.AccountName + "'";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                dbConnection.ExecuteNonQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return null;
        }
        public List<AccountBO> GetAccountInformationObject(string whereBy)
        {
            List<AccountBO> _accountList = new List<AccountBO>();
            string query = "SELECT [AccountId],[AccountName],[FullName],[Password],[AccountType],[AccessLevel],[CreateDate],[CreatedBy]  FROM [AccountTable] WHERE " + whereBy + " ORDER BY AccountId ASC";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                DataTable datatable = dbConnection.ExecuteQuery(query);
                for (int i = 0; i <= datatable.Rows.Count - 1; i++)
                {
                    AccountBO _accountInfo = new AccountBO();
                    if (datatable.Rows[i]["AccountId"] != DBNull.Value)
                    {
                        _accountInfo.AccountId = int.Parse(datatable.Rows[i]["AccountId"].ToString());
                    }
                    else
                    {
                        _accountInfo.AccountId = 0;
                    }
                    _accountInfo.AccessLevel = int.Parse(datatable.Rows[i]["AccessLevel"].ToString());
                    _accountInfo.AccountName = datatable.Rows[i]["AccountName"].ToString();
                    _accountInfo.AccountType = datatable.Rows[i]["AccountType"].ToString();
                    _accountInfo.FullName = datatable.Rows[i]["FullName"].ToString();
                    _accountInfo.Password = datatable.Rows[i]["Password"].ToString();
                    if (datatable.Rows[i]["CreateDate"] != DBNull.Value)
                    {
                        _accountInfo.CreateDate = Convert.ToDateTime(datatable.Rows[i]["CreateDate"]);
                    }
                    _accountList.Add(_accountInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return _accountList;
        }
        public DataTable GetAccountInfo()
        {
            DataTable data = new DataTable();
            string query = "SELECT [AccountId],[AccountName],[FullName],[Password],[AccountType],[AccessLevel],[CreateDate],[CreatedBy]  FROM [AccountTable] ORDER BY AccountId ASC";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                data = dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return data;
        }
        public DataTable GetAccountInfo(int __accountId)
        {
            DataTable data = new DataTable();
            string query = "SELECT [AccountId],[AccountName],[FullName],[Password],[AccountType],[AccessLevel],[CreateDate],[CreatedBy]  FROM [AccountTable] WHERE AccountId=" + __accountId;
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                data = dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return data;
        }
        public object DeleteAccountInformation(string __accountName)
        {
            string query = "DELETE FROM AccountTable WHERE AccountName='" + __accountName + "'";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                dbConnection.ExecuteNonQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return null;
        }
        public DataTable MemberAccountInformation(string __accountName)
        {
            DataTable data = new DataTable();
            string query = "SELECT [AccountId],[AccountName],[FullName],[Password],[AccountType],[AccessLevel],[CreateDate],[CreatedBy]  FROM [AccountTable] WHERE AccountName='" + __accountName + "'";
            DbConnection dbConnection = new DbConnection();
            try
            {
                dbConnection.ConnectDatabase();
                data = dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.CloseDatabase();
            }
            return data;
        }
    }
}