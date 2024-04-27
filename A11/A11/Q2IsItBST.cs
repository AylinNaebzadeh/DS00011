using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
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
        public bool Solve(long[][] nodes)
        {
            long[] inOrderTraversal = InOrder(nodes);

            for (long i = 1; i < inOrderTraversal.Length - 1; i++)
            {
                if (inOrderTraversal[i] < inOrderTraversal[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
