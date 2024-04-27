using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace E1
{
    public class Q2Cars : Processor
    {
        public Q2Cars(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ2Cars(inStr, Solve);
        public static double Distance(long aX, long aY, long bX, long bY)
        {
            return Math.Sqrt((Math.Pow((aX - bX), 2) + Math.Pow((aY - bY), 2)));
        }

        // public static Tuple<long, long> Cars(List<Tuple<long, long>> points, long left, long right, long p)
        // {

        // }

        public double Solve(long aX, long aY, long bX, long bY, long cX, long cY, long dX, long dY)
        {
            // var x_array = new long[]{aX, bX, cX, dX};
            // var y_array = new long[]{aY, bY, cY, dY};
            // var points = x_array.Zip(y_array, (x, y) => new Tuple<long, long>(x, y)).ToList();

            // long mid_1_x = (points[0].Item1 + points[1].Item1) / 2;
            // long mid_1_y = (points[0].Item2 + points[1].Item2) / 2;

            // long mid_2_x = (points[2].Item1 + points[3].Item1) / 2;
            // long mid_2_y = (points[2].Item2 + points[3].Item2) / 2;
            throw new NotImplementedException();
        }
    }
}
