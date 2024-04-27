using System.Collections.Generic;
using System.Text;

class HashingWithChains
{
        public static string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            List<string>[] input = new List<string>[bucketCount];
            for (long i = 0; i < bucketCount; i++)
            {
                input[i] = new List<string>();
            }
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg, input, bucketCount);
                        break;
                    case "del":
                        Delete(arg, input, bucketCount);
                        break;
                    case "find":
                        result.Add(Find(arg, input, bucketCount));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg), input));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                hash = (((hash * x) % p + (int)str[i] % p) + p) % p; 
            }
            return hash % count;
        }

        public static void Add(string str, List<string>[] input, long bucketCount)
        {
            List<string> L = new List<string>();
            L = input[PolyHash(str, 0, (int)bucketCount, BigPrimeNumber, ChosenX)];
            if (L.Contains(str))
            {
                return;
            }
            L.Insert(0, str);
        }

        public static string Find(string str, List<string>[] input, long bucketCount)
        {
            List<string> L = new List<string>();
            L = input[PolyHash(str, 0, (int)bucketCount, BigPrimeNumber, ChosenX)];
            if (L.Contains(str))
            {
                return "yes";
            }
            return "no";
        }

        public static void Delete(string str, List<string>[] input, long bucketCount)
        {
            if (Find(str, input, bucketCount) == "no")
            {
                return;
            }
            List<string> L = new List<string>();
            L = input[PolyHash(str, 0, (int)bucketCount, BigPrimeNumber, ChosenX)];
            L.Remove(str);
        }

        public static string Check(int i, List<string>[] input)
        {
            if (input[i].Count == 0)
            {
                return "";
            }
            StringBuilder res = new StringBuilder();
            
            for (int j = 0; j < input[i].Count; j++)
            {
                res.Append(input[i][j] + " ");
            }
            return res.ToString().TrimEnd();
        }
}