using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            long BigPrimeNumber = 1000000007;
            long ChosenX = 263;
            List<long> occurrences = new List<long>();
            long pHash = PolyHash(pattern, BigPrimeNumber, ChosenX);
            var H = PreComputeHashes(text, pattern.Length, BigPrimeNumber, ChosenX);
            // we need also a (+ 1) for upper bound
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
            // we need also a (+ 1) for upper bound
            for (long i = 1; i < P + 1; i++)
            {
                y = (y * x) % prime;
            }
            for (long i = T.Length - P - 1; i >= 0; i--)
            {
                // if we don't sum it wiht p it would be negetive in some cases
                Hashes[i] = (((x * Hashes[i + 1]) % prime + T[(int)i] - (y * T[(int)i + P]) % prime) + prime) % prime;
            }
            return Hashes;
        }
    }
}
