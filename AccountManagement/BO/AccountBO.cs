using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace AccountManagement
{
    public class AccountBO
    {
        private int _accountId;
        public int AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        private string _accountName;
        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _accountType;
        public string AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }
        private int _accessLevel;
        public int AccessLevel
        {
            get { return _accessLevel; }
            set { _accessLevel = value; }
        }
        private System.DateTime _createDate;
        public System.DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
    }
}