using System;
using System.Collections.Generic;

namespace A111
{



    class Program
    {
        public static long[] InOrder(long[][] nodes)
        {
            List<long> result = new List<long>();
            Stack<long> inOrder = new Stack<long>();
            long number_of_rows = nodes.GetLength(0);
            long cursor = 0;
            while (inOrder.Count != 0 || cursor != -1)
            {
                if (cursor >= 0 && cursor <= number_of_rows)
                {
                    inOrder.Push(cursor);
                    cursor = nodes[cursor][1];
                }
                else
                {
                    long visited = inOrder.Pop();
                    result.Add(nodes[visited][0]);
                    cursor = nodes[visited][2];
                }
            }
            return result.ToArray();
        }

        public static long[] PreOrder(long[][] nodes)
        {
            List<long> result = new List<long>();
            Stack<long> preOrder = new Stack<long>();
            long number_of_rows = nodes.GetLength(0);
            long cursor = 0;
            preOrder.Push(cursor);
            while (preOrder.Count != 0)
            {
                if (cursor >= 0 && cursor <= number_of_rows)
                {
                    result.Add(nodes[cursor][0]);
                    if (nodes[cursor][2] != -1)
                    {
                        preOrder.Push(nodes[cursor][2]);
                    }
                    cursor = nodes[cursor][1];
                }
                else
                {
                    cursor = preOrder.Pop();
                }
            }
            return result.ToArray();
        }

        public static long[] PostOrder(long[][] nodes)
        {
            Stack<long> result = new Stack<long>();
            Stack<long> postOrder = new Stack<long>();
            long cursor = 0;
            postOrder.Push(cursor);

            while (postOrder.Count != 0)
            {
                cursor = postOrder.Pop();
                result.Push(nodes[cursor][0]);

                if (nodes[cursor][1] != -1)
                {
                    postOrder.Push(nodes[cursor][1]);
                }

                if (nodes[cursor][2] != -1)
                {
                    postOrder.Push(nodes[cursor][2]);
                }
            }
            return result.ToArray();
        }
        // public static long[][] Solve(long[][] nodes)
        // {
        //     var inorder_res = InOrder(nodes);
        //     var preorder_res = PreOrder(nodes);
        //     var postorder_res = PostOrder(nodes);
        //     long[][] output = new long[][]
        //     {
        //         inorder_res,
        //         preorder_res,
        //         postorder_res,
        //     };
        //     return output;
        // }
        // public static bool Solve(long[][] nodes)
        // {
        //     long[] inOrderTraversal = InOrder(nodes);

        //     for (long i = 1; i < inOrderTraversal.Length - 1; i++)
        //     {
        //         if (inOrderTraversal[i] < inOrderTraversal[i - 1])
        //         {
        //             return false;
        //         }
        //     }
        //     return true;
        // }
        public static bool IsBSTHarder(long[][] nodes, long[] node, long minAssign, long maxAssign)
        {
            if (node.Length == 0)
            {
                return true;
            }

            if (node[0] < minAssign || node[0] >= maxAssign)
            {
                return false;
            }
            if ((node[1] != -1 && IsBSTHarder(nodes, nodes[node[1]], minAssign, node[0]) == false) || 
                (node[2] != -1 && IsBSTHarder(nodes, nodes[node[2]], node[0], maxAssign) == false))
                {
                    return false;
                }
            return true;
        }
        public static bool Solve(long[][] nodes)
        {
            if (IsBSTHarder(nodes, nodes[0], long.MinValue, long.MaxValue))
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            // long first_line = Convert.ToInt64(Console.ReadLine());
            // long[][] input = new long[first_line][];
            // for (long i = 0; i < first_line; i++)
            // {
            //     input[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            // }
            // var output = Solve(input);
            // for (long i = 0; i < 3; i++)
            // {
            //     System.Console.WriteLine(String.Join(" ", output[i]));
            // }
            // *********************************************************************************************
            long first_line = Convert.ToInt64(Console.ReadLine());
            if (first_line == 0)
            {
                System.Console.WriteLine("CORRECT");
                return;
            }
            long[][] input = new long[first_line][];
            for (long i = 0; i < first_line; i++)
            {
                input[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            }
            bool is_or_not = Solve(input);
            if (is_or_not == true)
            {
                System.Console.WriteLine("CORRECT");
            }
            else
            {
                System.Console.WriteLine("INCORRECT");
            }
        }
    }
}
