using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);


        protected Dictionary<int, string> PhoneBookDictionary;
        public string[] Solve(string [] commands)
        {
            PhoneBookDictionary = new Dictionary<int, string>();
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
                        Add(args[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number)
        {
            PhoneBookDictionary[number] = name;
        }

        public string Find(int number)
        {
            if (PhoneBookDictionary.ContainsKey(number))
            {
                return PhoneBookDictionary[number];
            }
            return "not found";
        }

        public void Delete(int number)
        {
            PhoneBookDictionary.Remove(number);
        }
    }
}
