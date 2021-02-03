using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace AccountManagement
{
    public static class LoginInformationBO
    {
        public static string accountName;
        public static System.DateTime logindatetime;
        public static string accountType;
        public static int accessLevel;
        public static string password;
        public static string UserFullName;
        public static int accountId;
    }
    public enum Role
    {
        User,
        Admin
    }
}