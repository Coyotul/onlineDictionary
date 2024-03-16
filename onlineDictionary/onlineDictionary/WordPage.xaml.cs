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
    /// Interaction logic for WordPage.xaml
    /// </summary>
    public partial class WordPage : Window
    {
        private Words _words = new Words();

        public WordPage(string word,string description,string imageSrc,string category, bool canUseButtons)
        {
            InitializeComponent();
            wordText.Text = word;
            descriptionText.Text = description;
            categoryText.Text = category;
            var bitmap = new BitmapImage(new Uri(imageSrc, UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmap;
            _words.GetWords();
            if(canUseButtons)
            {
                deleteWord.Visibility = Visibility.Visible;
                updateWord.Visibility = Visibility.Visible;
            }
            else
            {
                deleteWord.Visibility = Visibility.Collapsed;
                updateWord.Visibility = Visibility.Collapsed;
            }
        }

        private void updateWordButton(object sender, RoutedEventArgs e)
        {
            string imageSrc = _words.GetWordImgSource(wordText.Text);
            _words.DeleteWord(wordText.Text);
            _words.AddWord(wordText.Text,descriptionText.Text,imageSrc,categoryText.Text);
            _words.SetWords();
            Close();
        }

        private void deleteWordButton(object sender, RoutedEventArgs e)
        {
            _words.DeleteWord(wordText.Text);
            _words.SetWords();
            Close();
        }
    }
}
