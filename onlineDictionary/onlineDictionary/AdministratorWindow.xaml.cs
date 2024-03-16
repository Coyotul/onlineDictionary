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
    public partial class AdministratorWindow : Window
    {
        private Administrator _admin = new Administrator();
        private Words _words = new Words();

        public AdministratorWindow()
        {
            InitializeComponent();
            _admin.ReadCredentials();
            usernameText.Visibility = Visibility.Visible;
            username.Visibility = Visibility.Visible;
            passwordText.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            incorectCredentials.Visibility = Visibility.Collapsed;
            addWord.Visibility = Visibility.Collapsed;
            scrollViewer.Visibility = Visibility.Collapsed;
            updateList.Visibility = Visibility.Collapsed;
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
                if (_admin.SearchUser(userText, passText))
                {
                    incorectCredentials.Visibility = Visibility.Collapsed;
                    usernameText.Visibility = Visibility.Collapsed;
                    username.Visibility = Visibility.Collapsed;
                    passwordText.Visibility = Visibility.Collapsed;
                    password.Visibility = Visibility.Collapsed;
                    addWord.Visibility = Visibility.Visible;
                    scrollViewer.Visibility = Visibility.Visible;
                    updateList.Visibility = Visibility.Visible;
                    wordListBox.Visibility = Visibility.Visible;
                }
                else
                {
                    incorectCredentials.Visibility = Visibility.Visible;
                }
            }
        }

        private void addWordButton(object sender, RoutedEventArgs e)
        {
            AddWordWindow addWordWindow = new AddWordWindow();
            addWordWindow.Show();

        }

        private void deleteWordButton(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private Words Get_words()
        {
            return _words;
        }

        public void UpdateList()
        {
            wordListBox.Items.Clear();
            _words.GetWords();
            foreach (var word in _words.ReturnWords())
            {
                ListBoxItem newItem = new ListBoxItem();
                newItem.Content = word.Word;
                newItem.MouseDoubleClick += WordItem_MouseDoubleClick;
                wordListBox.Items.Add(newItem);
            }
        }

        private void WordItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = (ListBoxItem)sender;
            string selectedWord = (string)listBoxItem.Content;
            string description = _words.GetWord(selectedWord).Description;
            string category = _words.GetWord(selectedWord).Category;
            string imageSource = _words.GetWord(selectedWord).ImageSource;
            new WordPage(selectedWord, description, imageSource, category, true).Show();
        }

        private void updateListButton(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }
    }
}
