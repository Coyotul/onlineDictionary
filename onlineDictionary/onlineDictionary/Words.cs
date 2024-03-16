using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static onlineDictionary.Administrator;

namespace onlineDictionary
{
    internal class Words
    {
        private List<wordStruct> _words = new List<wordStruct>();
        private List<String> _category = new List<String>();
        private Random rnd = new Random();
        public struct wordStruct
        {
            public string Word {  get; set; }
            public string Description { get; set; }
            public string ImageSource { get; set; }
            public string Category {  get; set; }
        }


        public void GetWords()
        {
            try
            {
                string jsonText = File.ReadAllText("words.json");
                _words = JsonSerializer.Deserialize<List<wordStruct>>(jsonText);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fisier negasit");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Eroare la citirea JSON-ului: " + ex.Message);
            }
        }

        public List<wordStruct> ReturnWords()
        {
            return _words;
        }

        public void SetWords()
        {
            try
            {
                string jsonText = JsonSerializer.Serialize(_words);
                File.WriteAllText("words.json", jsonText);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Eroare la scrierea JSON-ului: " + ex.Message);
            }
        }

        public void AddWord(string word, string description,string Category)
        {
            wordStruct w = new wordStruct();
            w.Word = word;
            w.Description = description;
            w.ImageSource = "no_image.png";
            w.Category = Category;
            _words.Add(w);
        }

        public void AddWord(string word, string description, string imageSource, string Category)
        {
            wordStruct w = new wordStruct();
            w.Word = word;
            w.Description = description;
            w.ImageSource = imageSource;
            w.Category = Category;
            _words.Add(w);
        }

        public void DeleteWord(string wordName)
        {
            foreach (wordStruct word in _words)
            {
                if(word.Word.Equals(wordName))
                { _words.Remove(word); return; }
            }
        }
        public string GetWordImgSource(string wordName)
        {
            foreach (wordStruct word in _words)
            {
                if (word.Word.Equals(wordName))
                { return word.ImageSource; }
            }
            return "C:\\Users\\George\\source\\repos\\onlineDictionary\\onlineDictionary\\onlineDictionary\\bin\\Debug\\no_image.png";
        }
        public wordStruct GetWord(string wordName)
        {
            foreach (wordStruct word in _words)
            {
                if (word.Word.Equals(wordName))
                { return word; }
            }
            return new wordStruct();
        }

        public wordStruct GetRandomWord()
        {
            int num = rnd.Next(0,_words.Count);
            return _words[num];
        }
    }
}
