using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q2Froggie : Processor
    {
        public Q2Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[][] myArray = new long[2][];
            myArray[0] = new long[n];
            myArray[1] = new long[n];
            myArray[0][0] = numbers[0][0];
            myArray[1][0] = numbers[1][0];
            for (long i = 0; i < numbers.Length - 1; i++)
            {
                for (long j = 1; j < n; j++)
                {
                    // for upper row
                    var up_up = numbers[i][j] + myArray[i][j-1];
                    // or 
                    var up_down = numbers[i][j] + myArray[i+1][j-1] - p;
                    if (up_up > up_down)
                    {
                        myArray[i][j] = up_up;
                    }
                    else
                    {
                        myArray[i][j] = up_down;
                    }
                    // for lower row
                    var down_down = numbers[i+1][j] + myArray[i+1][j-1];
                    // or
                    var down_up = numbers[i+1][j] + myArray[i][j-1] - p;
                    if (down_down > down_up)
                    {
                        myArray[i+1][j] = down_down;
                    }
                    else
                    {
                        myArray[i+1][j] = down_up;
                    }
                }
            }
            return Math.Max(myArray[0][myArray[0].Length - 1], myArray[1][myArray[1].Length - 1]);
        }
    }
}
