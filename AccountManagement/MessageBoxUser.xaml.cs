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
    /// Interaction logic for MessageBoxUser.xaml
    /// </summary>
    public partial class MessageBoxUser : Window
    {
        public Boolean _result = false; 

        public MessageBoxUser()
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

        private void btNo_Click(object sender, RoutedEventArgs e)
        {
            _result = false ;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            _result = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true ;
            this.Visibility = System.Windows.Visibility.Hidden;
        }
        public void ShowMessageBOX(string message, string title,int buttonNo,int buttonInfo)
        {
            lblMessageTitle.Content = title;
            lblMessageInfo.Text = message;

            if (buttonNo == 2)
            {
                btnOk.Content = "Yes";
                btNo.Visibility = System.Windows.Visibility.Visible;
                btNo.Content = "No";
            }
            else
            {
                btnOk.Content = "OK";
                btNo.Visibility = System.Windows.Visibility.Hidden;
                borderNo.Visibility = System.Windows.Visibility.Hidden;
            }

            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();

            if(buttonInfo ==1)
                bi3.UriSource  = new Uri("/MemberShipAccount;component/Image/icontexto_user_web20_whosamungus.png", UriKind.Relative);
            else if (buttonInfo ==2)
                bi3.UriSource = new  Uri("/MemberShipAccount;component/Image/QuestionLog.png", UriKind.Relative);
            else if (buttonInfo ==3)
                bi3.UriSource = new  Uri("/MemberShipAccount;component/Image/WarningLog.png", UriKind.Relative);
            else
                bi3.UriSource = new  Uri("/MemberShipAccount;component/Image/ErrorMessage.png", UriKind.Relative);
            
            bi3.EndInit();
            myImage3.Stretch = Stretch.Fill;
            myImage3.Source = bi3;
            this.ShowDialog();
        }
    }
}
