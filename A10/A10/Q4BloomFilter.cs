// Bloom filter: https://www.jasondavies.com/bloomfilter/

using System;
using System.Collections;
using System.Linq;
using TestCommon;


namespace A10
{
    public class Q4BloomFilter
    {
        public BitArray Filter{get; set;}
        // input --> string
        // output --> int
        // https://www.tutorialsteacher.com/csharp/csharp-func-delegate
        public Func<string, int>[] HashFunctions{get; set;}
        public int filterSize{get; set;}
        public Q4BloomFilter(int filterSize, int hashFnCount)
        {
            // Write your code here to Initialize 'Filter' and 'HashFunctions' ... 
            this.filterSize = filterSize;
            Filter = new BitArray(filterSize, false);
            HashFunctions = new Func<string, int>[4];
            HashFunctions[0] = delegate(string input)
                                    {
                                        int hash = 0;
                                        for (int i = 0; i < input.Length; i++)
                                        {
                                            hash += (input[i]) % this.filterSize;
                                        }
                                        return hash;
                                    };
            HashFunctions[1] = delegate(string input)
                                    {
                                        int hash = 7;
                                        for (int i = 0; i < input.Length; i++)
                                        {
                                            hash = (hash * 31 + input[i]) % this.filterSize;
                                        }
                                        return hash % this.filterSize;
                                    };
            HashFunctions[2] = delegate(string input)
                                    {
                                        long hash = 3;
                                        int prime = 7;
                                        for (int i = 0; i < input.Length; i++)
                                        {
                                            hash += hash * 7 + input[0] * (int)Math.Pow(prime, i);
                                            hash = hash % this.filterSize;
                                        }
                                        if (hash < 0)
                                        {
                                            hash += this.filterSize;
                                        }
                                        return (int)hash;
                                    };
            // https://stackoverflow.com/questions/9545619/a-fast-hash-function-for-string-in-c-sharp
            HashFunctions[3] = delegate(string input)
                                    {
                                        UInt64 hashedValue = 3074457345618258791ul;
                                        for (int i = 0; i < input.Length; i++)
                                        {
                                            hashedValue += input[i];
                                            hashedValue *= 3074457345618258799ul;
                                        }
                                        int result = (int) hashedValue % this.filterSize;
                                        if (result < 0)
                                        {
                                            result += this.filterSize;
                                        }
                                        return result;
                                    };

        }
        public void Add(string str)
        {
            for (int i=0; i< HashFunctions.Length; i++)
            {
                Filter[HashFunctions[i](str)] = true;
            }
        }

        public bool Test(string str)
        {
            for (int i=0; i<HashFunctions.Length; i++)
            {
                if (Filter[HashFunctions[i](str)] == true)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}