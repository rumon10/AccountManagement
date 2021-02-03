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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private MessageBoxUser _message = new MessageBoxUser();

        public Login()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            this.UserLogin();
        }

        public void UserLogin()
        {
            try
            {
                if (String.IsNullOrEmpty(txtAccountName.Text.Trim()) == true && string.IsNullOrEmpty(txtpassword.Password) == true)
                {
                    _message.ShowMessageBOX("Both Account name & Password are required to login Account Management System. Please enter the account name & Password.", "Account Name & Password Required!", 1, 3);
                    return ;
                }

                if (string.IsNullOrEmpty(txtAccountName.Text.Trim()) == true)
                {
                    _message.ShowMessageBOX ("Account name is required to login Account Management System. Please enter the account name.", "Account Name Required!", 1, 3);
                    return;
                }

                if (string.IsNullOrEmpty(txtpassword.Password) == true)
                {
                    _message.ShowMessageBOX ("Password is required to login Account Management System. Please enter the valid password.", "Password Required!", 1, 3);
                    return;
                }

                AccountInformation accountInfo = new AccountInformation();
                if (accountInfo.IsAunthenticatedUser(txtAccountName.Text.Trim(), txtpassword.Password) == true)
                {
                    AccountRegistration registration = new AccountRegistration();
                    registration.Show();
                    this.Close();
                }

                else
                { 
                    _message.ShowMessageBOX ("Invalid Account Name & Password. Please try to login  with valid account name & password.", "Wrong account Name & Password", 1, 3);
                    txtAccountName.Text = String.Empty;
                    txtpassword.Password = String.Empty;
                    txtAccountName.Focus();
                    return;
                }


            }
            catch (Exception ex)
            {
                _message.ShowMessageBOX (ex.Message, "Error", 1, 4);
            }
        }

    }
}
