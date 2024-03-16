using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for EntertainmentWindowxaml.xaml
    /// </summary>
    public partial class EntertainmentWindow : Window
    {
        private List<Words.wordStruct> _wordsToGuess = new List<Words.wordStruct>();
        private List<bool> _imageOrDescription = new List<bool>();
        private int i = 0;
        private int _correctAnswers = 0;
        private Random rnd = new Random();
        private bool _answerGiven = false;

        public EntertainmentWindow()
        {
            InitializeComponent();
            Words _words = new Words();
            _words.GetWords();
            while(_wordsToGuess.Count <5)
            {
                Words.wordStruct word = _words.GetRandomWord();
                bool canAdd = true;
                foreach(Words.wordStruct wordToCheck in _wordsToGuess)
                {
                    if (word.Word == wordToCheck.Word)
                    {
                        canAdd = false;
                    }
                }
                if (!canAdd)
                    continue;
                _wordsToGuess.Add(word);
                if(word.ImageSource != "C:\\Users\\George\\source\\repos\\onlineDictionary\\onlineDictionary\\onlineDictionary\\bin\\Debug\\no_image.png")
                {
                    int num = rnd.Next(0, 2);
                    if (num == 0)
                        _imageOrDescription.Add(false);
                    else
                        _imageOrDescription.Add(true);
                }
                else
                    _imageOrDescription.Add(false);
            }
            description.Text = _wordsToGuess[i].Description;
            string imageSrc = _wordsToGuess[i].ImageSource;
            var bitmap = new BitmapImage(new Uri(imageSrc, UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmap;
            if (_imageOrDescription[i])
            {
                description.Visibility = Visibility.Collapsed;
                imageControl.Visibility = Visibility.Visible;
            }
            else
            {
                description.Visibility = Visibility.Visible;
                imageControl.Visibility = Visibility.Collapsed;
            }
        }

        private void wordText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnClickNext(object sender, RoutedEventArgs e)
        {
            if(nextButton.Content == "Finish")
            {
                FinishGame();
            }
            if (i != 4)
            {
                i++;
                Round.Text = (i+1).ToString() + "/5";
            }
            if (i != 0 && !_answerGiven)
            {
                prevButton.Visibility = Visibility.Visible;
            }
            if (i == 4)
            {
                nextButton.Content = "Finish";
            }
            else
            {
                nextButton.Content = "Next";
            }
            description.Text = _wordsToGuess[i].Description;
            string imageSrc = _wordsToGuess[i].ImageSource;
            var bitmap = new BitmapImage(new Uri(imageSrc, UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmap;
            if (_imageOrDescription[i])
            {
                description.Visibility = Visibility.Collapsed;
                imageControl.Visibility = Visibility.Visible;
            }
            else
            {
                description.Visibility = Visibility.Visible;
                imageControl.Visibility = Visibility.Collapsed;
            }
        }

        private void OnClickPrev(object sender, RoutedEventArgs e)
        {
            if (i != 0)
            {
                i--;
                Round.Text = (i+1).ToString() + "/5";
            }
            if (i == 0)
            {
                prevButton.Visibility = Visibility.Collapsed;
            }
            description.Text = _wordsToGuess[i].Description;
            string imageSrc = _wordsToGuess[i].ImageSource;
            var bitmap = new BitmapImage(new Uri(imageSrc, UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmap;
            if (_imageOrDescription[i])
            {
                description.Visibility = Visibility.Collapsed;
                imageControl.Visibility = Visibility.Visible;
            }
            else
            {
                description.Visibility = Visibility.Visible;
                imageControl.Visibility = Visibility.Collapsed;
            }
        }

        private void FinishGame()
        {
            string text = "Congrats! You got " + _correctAnswers + "/5";
            MessageBox.Show(text);
            Close();
        }

        private void wordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                if (wordText.Text == _wordsToGuess[i].Word)
                {
                    _correctAnswers++;
                    MessageBox.Show("Correct!", "Guessing Game", MessageBoxButton.OK);
                    wordText.Text = "";
                    OnClickNext(sender, e);
                    prevButton.Visibility = Visibility.Collapsed;
                    _answerGiven = true;
                }
                else
                {
                    string textToShow = "Wrong!\n" + "The word was: " + _wordsToGuess[i].Word;
                    MessageBox.Show(textToShow, "Guessing Game", MessageBoxButton.OK);
                    wordText.Text = "";
                    OnClickNext(sender, e);
                    _answerGiven = true;
                    prevButton.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
