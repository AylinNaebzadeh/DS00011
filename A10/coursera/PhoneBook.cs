using System.Collections.Generic;
using System.Linq;

class PhoneBook
{
        public static string[] Solve(string[] commands)
        {
            Dictionary<int, string> PhoneBookDictionary = new Dictionary<int, string>();
            List<string> result = new List<string>();
            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number, PhoneBookDictionary);
                        break;
                    case "del":
                        Delete(number, PhoneBookDictionary);
                        break;
                    case "find":
                        result.Add(Find(number, PhoneBookDictionary));
                        break;
                }
            }
            return result.ToArray();
        }

        public static void Add(string name, int number, Dictionary<int, string> PhoneBookDictionary)
        {
            PhoneBookDictionary[number] = name;
        }

        public static string Find(int number, Dictionary<int, string> PhoneBookDictionary)
        {
            if (PhoneBookDictionary.ContainsKey(number))
            {
                return PhoneBookDictionary[number];
            }
            return "not found";
        }

        public static void Delete(int number, Dictionary<int, string> PhoneBookDictionary)
        {
            PhoneBookDictionary.Remove(number);
        }
}