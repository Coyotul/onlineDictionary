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

        public struct wordStruct
        {
            public string Word {  get; set; }
            public string Description { get; set; }
            public string ImageSource { get; set; }
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

        public void AddWord(string word, string description)
        {
            wordStruct w = new wordStruct();
            w.Word = word;
            w.Description = description;
            w.ImageSource = "no_image.png";
            _words.Add(w);
        }

        public void AddWord(string word, string description, string imageSource)
        {
            wordStruct w = new wordStruct();
            w.Word = word;
            w.Description = description;
            w.ImageSource = imageSource;
            _words.Add(w);
        }

    }
}
