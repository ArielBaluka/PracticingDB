using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using ViewModel;

namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserDB userDB = new UserDB();
            User user = new User();
            user.UserName = tbxNmae.Text;
            user.Password = tbxPassword.Password;
            tbxNmae.Text = tbxPassword.Password = string.Empty;

            User us = userDB.Login(user);
            if(us != null)
            {
                if(us.IsAdmin)
                {
                    MessageBox.Show("nice Login");
                    MainWindow mW = new MainWindow();
                    mW.ShowDialog();
                }
                else
                {
                    MessageBox.Show("no admin detected");
                }
            }
            else
            {
                MessageBox.Show("BAD Login");
            }
        }
    }
}
