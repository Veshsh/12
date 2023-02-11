using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace _12DayBook
{
    internal class Ster
    {
        public const string Sterfile = "\\source\\repos\\12DayBook\\Sterfile.json";
        public static List<Note> data = dester<List<Note>>(Sterfile);
        public static void ster<T>(T listdata, string paff)
        {
            string paf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string json = JsonConvert.SerializeObject(listdata);
            File.WriteAllText(paf + paff, json);
        }
        public static T dester<T>(string paff)
        {
            string paf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string jsontext = File.ReadAllText(paf + paff);
            T list = JsonConvert.DeserializeObject<T>(jsontext);
            return list;
        }
    }
}
