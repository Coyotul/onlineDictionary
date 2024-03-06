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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace onlineDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        Administrator admin = new Administrator();

        public AdministratorWindow()
        {
            InitializeComponent();
            admin.ReadCredentials();
            usernameText.Visibility = Visibility.Visible;
            username.Visibility = Visibility.Visible;
            passwordText.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            incorectCredentials.Visibility = Visibility.Collapsed;
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && username.IsFocused)
            {
                password.Focus();
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && password.IsFocused)
            {
                String userText = username.Text;
                String passText = password.Text;
                if (admin.SearchUser(userText, passText))
                {
                    MessageBox.Show("Utilizatorul exista");
                }
                else
                {
                    incorectCredentials.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
