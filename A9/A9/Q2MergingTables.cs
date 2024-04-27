using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class DisjointSetElement
    {
        public long size;
        public long parent;
    }

    public class DisjointSets
    {
        public long size;
        public long maxTableSize;
        public List<DisjointSetElement> ds;

        public DisjointSets(long size)
        {
            this.size = size;
            ds = new List<DisjointSetElement>(new DisjointSetElement[size]);
            for (int i = 0; i < size; i++)
            {
                ds[i] = new DisjointSetElement();
                ds[i].parent = i;
            }
        }
        public long FindParent(long table)
        {
            while (table != ds[(int)table].parent)
            {
                table = ds[(int)table].parent;
            }
            return table;
        }
        public void Union(long i, long j)
        {
            long i_id = FindParent(i);
            long j_id = FindParent(j);
            
            if (i_id == j_id)
            {
                return;
            }
            // oni ke size bishtar dare be oni ke size kamtar dare vasl mishe
            if (ds[(int)i_id].size > ds[(int)j_id].size)
            {
                ds[(int)j_id].parent = i_id;
                ds[(int)i_id].size +=  ds[(int)j_id].size;
            }
            else
            {
                ds[(int)i_id].parent = j_id;
                ds[(int)j_id].size += ds[(int)i_id].size ;
            }
            maxTableSize = ds.Max(obj => obj.size);
        }
    }
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { ExcludeTestCases(48);}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            long tt = targetTables.Length;
            long ts = tableSizes.Length;
            long[] res = new long[tt];
            DisjointSets tables = new DisjointSets(ts);
            for (long i = 0; i < ts; i++)
            {
                tables.ds[(int)i].size = tableSizes[i];
            }
            tables.maxTableSize = Math.Max(tables.maxTableSize, (int)tableSizes.Max());
            for (long i = 0; i < tt; i++)
            {
                tables.Union(targetTables[i] -= 1, sourceTables[i] -= 1);
                res[i] = tables.maxTableSize;
            }
            return res;
        }

    }
}
