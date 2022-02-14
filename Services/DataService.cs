using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using JsonShowcase.Models;
using Newtonsoft.Json;

namespace JsonShowcase.Services
{
    public class DataService
    {

        private static List<User> data = new List<User>();

        // This method is called in Startup.cs
        // Used to initially read all contents of the Users.json file into the data List
        public static void Init()
        {
            DataService service = new DataService();

            // Read json into a string and then Deserialize the string using the User class
            string json = File.ReadAllText("wwwroot/data/Users.json");
            data = JsonConvert.DeserializeObject<List<User>>(json);

        }

        // Simply returns the List of User objects
        public static List<User> GetData()
        {
            return data;

        }

        // Add the new object to the List and then overwrite the json file with the new data List
        // (the list includes the new object we just added to it)
        public static void PushData(User user)
        {
            data.Add(user);
            File.WriteAllText("wwwroot/data/Users.json", JsonConvert.SerializeObject(data));
        }
    }
}
