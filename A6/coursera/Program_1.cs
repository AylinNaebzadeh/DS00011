// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace coursera
// {
//     class Program
//     {

//     private static readonly int[] COINS = new int[] {1, 3, 4};
//     public long Solve(long n)
//     {
//         long[] MinNumberCoins = new long[n+1];
//         MinNumberCoins[0] = 0;
//         long NumCoins = 0;

//         for (long m = 1; m <= n; m++)
//         {
//             MinNumberCoins[m] = long.MaxValue;
//             for (long i = 0; i < COINS.Length; i++)
//             {
//                 if (m >= COINS[i])
//                 {
//                     NumCoins = MinNumberCoins[m - COINS[i]] + 1;
//                     if (NumCoins < MinNumberCoins[m])
//                     {
//                         MinNumberCoins[m] = NumCoins;
//                     }
//                 }
//             }
//         }
//         return MinNumberCoins[n];
//     }
//         #region Calculator
//         private static List<long> RemainderGenerator(long n, long divisor)
//         {
//             List<long> remainders = new List<long>();
//             for (long i = n - n % divisor; i < n + 1; i++)
//             {
//                 remainders.Add(i);
//             }
//             return remainders;
//         }

//         public static Tuple<long,long[]> Solve(long n)
//         {
//             if (n == 1)
//             {
//                 return new Tuple<long, long[]>(0, new long[]{1});
//             }
//             long[] dp_operations_count = new long[n + 1];
//             dp_operations_count[0] = 0;
//             dp_operations_count[1] = 0;
//             dp_operations_count[2] = 1;
//             long[][] dp_sequences = new long[n + 1][];
//             dp_sequences[0] = new long[]{0};
//             dp_sequences[1] = new long[]{1};
//             dp_sequences[2] = new long[]{1, 2};
//             for (long i = 3; i <= n; i++)
//             {
//                 long q_3 = dp_operations_count[i / 3] + i % 3 + 1;
//                 long q_2 = dp_operations_count[i / 2] + i % 2 + 1;
//                 dp_operations_count[i] = Math.Min(q_3, q_2);

//                 if (q_3 < q_2)
//                 {
//                     var remainders = RemainderGenerator(i, 3);
//                     dp_sequences[i] = dp_sequences[i / 3].ToList().Concat(remainders).ToArray();
//                 }
//                 else
//                 {
//                     var remainders = RemainderGenerator(i, 2);
//                     dp_sequences[i] = dp_sequences[i / 2].ToList().Concat(remainders).ToArray();
//                 }
//             }
//             return new Tuple<long, long[]>(dp_operations_count[n], dp_sequences[n]);
//         }
//         #endregion

//         #region LCS3
//         public static long Solve(long[] seq1, long[] seq2, long[] seq3)
//         {
//             long seq1_length = seq1.Length;
//             long seq2_length = seq2.Length;
//             long seq3_length = seq3.Length;

//             long[,,] DP = new long[seq1_length + 2, seq2_length + 2, seq3_length + 2];
//             // i 0 --> seq1.length

//             for (long i = 1; i < seq1_length + 1; i++)
//             {
//                 for (long j = 1; j < seq2_length + 1; j++)
//                 {
//                     for (long k = 1; k < seq3_length + 1; k++)
//                     {
//                         // har 3 ba ham mosavi bodan --> i-1, j - 1, k-1
//                         // max(i-1, j, k| i, j, k-1| i, j-1 ,k)
//                         if (seq1[i - 1] == seq2[j - 1] && seq2[j - 1] == seq3[k - 1])
//                         {
//                             DP[i, j, k] = 1 + DP[i - 1, j - 1, k - 1];
//                         }
//                         else
//                         {
//                             DP[i, j, k] = Math.Max(DP[i - 1, j, k], Math.Max(DP[i, j, k - 1], DP[i, j - 1, k]));
//                         }
//                     }
//                 }
//             }
//             return DP[seq1_length, seq2_length, seq3_length];
//         }
//         #endregion
//         static void Main(string[] args)
//         {
//             // var input = Convert.ToInt64(Console.ReadLine());
//             // var res = Solve(input);
//             // System.Console.WriteLine(res.Item1);
//             // for (long i = 0; i < res.Item2.Count(); i++)
//             // {
//             //     System.Console.Write(res.Item2[i] + " ");
//             // }
//             // *****************************************************
//             var first = Convert.ToInt64(Console.ReadLine());
//             long[] first_arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);
//             var second = Convert.ToInt64(Console.ReadLine());
//             long[] second_arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);
//             var third = Convert.ToInt64(Console.ReadLine());
//             long[] third_arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);
//             System.Console.WriteLine(Solve(first_arr, second_arr, third_arr));
//         }
//     }
// }
