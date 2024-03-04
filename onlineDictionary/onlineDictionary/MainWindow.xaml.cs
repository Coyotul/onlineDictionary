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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickAdmin(object sender, RoutedEventArgs e)
        {
            AdministratorWindow administratorWindow = new AdministratorWindow();
            administratorWindow.Show();
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();
        }

        private void OnClickEntertainment(object sender, RoutedEventArgs e)
        {
            EntertainmentWindow entertainmentWindow = new EntertainmentWindow();
            entertainmentWindow.Show();
        }
    }
}
