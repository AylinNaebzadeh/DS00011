using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A100
{
    class Program
    {
        #region Q1
        // public static string[] Solve(string[] commands)
        // {
        //     Dictionary<int, string> PhoneBookDictionary = new Dictionary<int, string>();
        //     List<string> result = new List<string>();
        //     foreach(var cmd in commands)
        //     {
        //         var toks = cmd.Split();
        //         var cmdType = toks[0];
        //         var args = toks.Skip(1).ToArray();
        //         int number = int.Parse(args[0]);
        //         switch (cmdType)
        //         {
        //             case "add":
        //                 Add(args[1], number, PhoneBookDictionary);
        //                 break;
        //             case "del":
        //                 Delete(number, PhoneBookDictionary);
        //                 break;
        //             case "find":
        //                 result.Add(Find(number, PhoneBookDictionary));
        //                 break;
        //         }
        //     }
        //     return result.ToArray();
        // }

        // public static void Add(string name, int number, Dictionary<int, string> PhoneBookDictionary)
        // {
        //     PhoneBookDictionary[number] = name;
        // }

        // public static string Find(int number, Dictionary<int, string> PhoneBookDictionary)
        // {
        //     if (PhoneBookDictionary.ContainsKey(number))
        //     {
        //         return PhoneBookDictionary[number];
        //     }
        //     return "not found";
        // }

        // public static void Delete(int number, Dictionary<int, string> PhoneBookDictionary)
        // {
        //     PhoneBookDictionary.Remove(number);
        // }
        #endregion
        #region Q2
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
        #endregion
        #region Q3
        public static long[] Solve(string pattern, string text)
        {
            long BigPrimeNumber = 1000000007;
            long ChosenX = 263;
            List<long> occurrences = new List<long>();
            long pHash = PolyHash(pattern, BigPrimeNumber, ChosenX);
            var H = PreComputeHashes(text, pattern.Length, BigPrimeNumber, ChosenX);
            // +1 kam dasht
            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if (pHash != H[i])
                {
                    continue;
                }
                if (String.Equals(text.Substring(i, pattern.Length), pattern))
                {
                    occurrences.Add(i);
                }
            }
            return occurrences.ToArray();
        }

        public static long PolyHash(string str, long p, long x)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                // +p ezafi bod
                hash = (((hash * x) % p + (int)str[i] % p) + p) % p; 
            }
            return hash;
        }

        public static long[] PreComputeHashes(string T, int P, long prime, long x)
        {
            long[] Hashes = new long[T.Length - P + 1];
            string S = T.Substring(T.Length - P, P);
            Hashes[T.Length - P] = PolyHash(S, prime, x);
            long y = 1;
            // + 1
            for (long i = 1; i < P + 1; i++)
            {
                y = (y * x) % prime;
            }
            for (long i = T.Length - P - 1; i >= 0; i--)
            {
                Hashes[i] = (((x * Hashes[i + 1]) % prime + T[(int)i] - (y * T[(int)i + P]) % prime) + prime) % prime;
            }
            return Hashes;
        }
        #endregion
        static void Main(string[] args)
        {
            // ***************************************************************
            // long number_of_queries = Convert.ToInt64(Console.ReadLine());
            // string[] queries = new string[number_of_queries];
            // for (long i = 0; i < number_of_queries; i++)
            // {
            //     queries[i] = Console.ReadLine();
            // }
            // var result = Solve(queries);
            // for (long i = 0; i < result.Length; i++)
            // {
            //     System.Console.WriteLine(result[i]);
            // }
            // ***************************************************************
            // long the_number_of_buckets = Convert.ToInt64(Console.ReadLine());
            // long the_number_of_queries = Convert.ToInt64(Console.ReadLine());
            // string[] queries = new string[the_number_of_queries];
            // for (long i = 0; i < the_number_of_queries; i++)
            // {
            //     queries[i] = Console.ReadLine();
            // }
            // var result = Solve(the_number_of_buckets, queries);
            // for (long i = 0; i < result.Length; i++)
            // {
            //     System.Console.WriteLine(result[i]);
            // }
            // ***************************************************************
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            var res = Solve(pattern, text);
            string output = String.Join(" ", res.Select(item => item.ToString()).ToArray());
            System.Console.WriteLine(output);
        }
    }
}
