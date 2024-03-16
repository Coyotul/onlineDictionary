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

namespace onlineDictionary
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        String category = null;
        Words _words = new Words();
        public SearchWindow()
        {
            InitializeComponent();
            _words.GetWords();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            wordListBox.Items.Clear();
            _words.GetWords();
            foreach (var word in _words.ReturnWords())
            {
                ListBoxItem newItem = new ListBoxItem();
                newItem.Content = word.Word;
                newItem.MouseDoubleClick += WordItem_MouseDoubleClick;
                SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);
                newItem.Background = whiteBrush;
                if (word.Word.StartsWith(search.Text))
                {
                    if (category == null)
                        wordListBox.Items.Add(newItem);
                    else if (category == word.Category)
                        wordListBox.Items.Add(newItem);
                }
            }
        }

        private void WordItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = (ListBoxItem)sender;
            string selectedWord = (string)listBoxItem.Content;
            string description = _words.GetWord(selectedWord).Description;
            string category = _words.GetWord(selectedWord).Category;
            string imageSource = _words.GetWord(selectedWord).ImageSource;
            new WordPage(selectedWord, description, imageSource, category, false).Show();
        }

        private void category_TextChanged(object sender, TextChangedEventArgs e)
        {
            category = categoryBox.Text;
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter || e.Key == Key.Return)
            {

                string selectedWord = _words.GetWord(search.Text).Word;
                string description = _words.GetWord(selectedWord).Description;
                string category = _words.GetWord(selectedWord).Category;
                string imageSource = _words.GetWord(selectedWord).ImageSource;
                if (selectedWord != null)
                {
                    new WordPage(selectedWord, description, imageSource, category, false).Show();
                }
            }
        }
    }
}
