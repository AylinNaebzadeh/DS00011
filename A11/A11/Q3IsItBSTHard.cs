using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

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
    }
}
