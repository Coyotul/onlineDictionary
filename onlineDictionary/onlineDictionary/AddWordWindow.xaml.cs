using Microsoft.Win32;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddWordWindow : Window
    {
        String _imageSource = "no_image.png";
        public AddWordWindow()
        {
            InitializeComponent();
        }

        private void imageSource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void description_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addWordButton(object sender, RoutedEventArgs e)
        {
            if (word.Text.Length != 0 && description.Text.Length != 0)
            {

                Words _words = new Words();
                _words.GetWords();
                _words.AddWord(word.Text, description.Text, _imageSource);
                _words.SetWords();
                Close();
            }
        }

        private void word_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void chooseImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Fișiere de imagine (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Toate fișierele (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _imageSource = openFileDialog.FileName;
            }
        }

    }
}
