using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace onlineDictionary
{
    internal class Administrator
    {
        private bool _isLogged { get; set; }
        private List<admin> _users = new List<admin>();
        public struct admin
        {
            public string Username {  get; set; }
            public string Password { get; set; }
        }

        public Administrator() { }

        public void ReadCredentials()
        {
            try
            {
                string jsonText = File.ReadAllText("admins.json");
                _users = JsonSerializer.Deserialize<List<admin>>(jsonText);
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

        public bool SearchUser(String username, String password)
        {
            foreach(var user in _users)
            {
                if (user.Username == username && user.Password == password)
                    return true;
            }
            return false;
        }

    }
}
