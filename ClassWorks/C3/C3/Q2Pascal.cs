using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q2Pascal : Processor
    {
        public Q2Pascal(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long>)Solve);

        private static long[,] MatrixMultiply(long[,] m1, long[,] m2)
        {
            long[,] result = new long[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    long tmp = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        tmp += (m1[i , k] * m2[k, j]);
                    }
                    result[i , j] = tmp % (MyPower(10 , 9) + 7);
                }
            }
            return result;
        } 

        private static long[,] MatrixPower(long[,] matrix, long pow)
        {
            var M = new long[,]{{1 , 1},{1 , 0}};
            if (pow == 0)
            {
                return new long[2, 2]{{1, 0} , {0 , 1}};
            }
            if (pow % 2 == 0)
            {
                return MatrixPower(MatrixMultiply(matrix , matrix) , pow / 2);
            }

            else
            {
                return MatrixMultiply(matrix , MatrixPower(MatrixMultiply(matrix , matrix) , pow / 2));
            }
        }
        // 4 ** 2
        private static long MyPower(long n, long m)
        {
            if (m == 0)
            {
                return 1;
            }
            if (m % 2 == 0)
            {
                return MyPower(n * n, m / 2);
            }

            else
            {
                return  n * MyPower(n * n, m / 2);
            }
        }



        public static long Solve(long n)
        {
            var MyArray = new long[2,2]{{1, 1} , {1, 0}};
            var m = MatrixPower(MyArray, n);
            return m[0, 1] % (MyPower(10, 9) + 7);
        }
    }
}
