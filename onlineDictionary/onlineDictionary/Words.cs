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
                Console.WriteLine("Eroare la parsarea JSON-ului: " + ex.Message);
            }
        }

        public void AddWord(string word, string description)
        {
            wordStruct w = new wordStruct();
            w.Word = word;
            w.Description = description;
            w.ImageSource = "no_image.png";
        }

        public void AddWord(string word, string description, string imageSource)
        {
            wordStruct w = new wordStruct();
            w.Word = word;
            w.Description = description;
            w.ImageSource = imageSource;
        }

    }
}
