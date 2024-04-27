class MaxOfArthmeticExpression
{
        public static long Eval(long a, long b, string op)
        {
            if (op == "*")
            {
                return a * b;
            }
            else if (op == "+")
            {
                return a + b;
            }
            else if (op == "-")
            {
                return a - b;
            }
            return 0;
        }
        public static void GetMinMax(List<string> op, long i, long j, string expression, long[,] M, long[,] m)
        {
            long min = long.MaxValue;
            long max = long.MinValue; 
            for (long k = i; k < j; k++)
            {
                long a = Eval(M[i, k], M[k + 1, j], op[(int)k]);
                long b = Eval(M[i, k], m[k + 1, j], op[(int)k]);
                long c = Eval(m[i, k], M[k + 1, j], op[(int)k]);
                long d = Eval(m[i, k], m[k + 1, j], op[(int)k]);
                min = new long[]{min, a, b, c, d}.Min();
                max = new long[]{max, a, b, c, d}.Max();
            }
            m[i, j] = min;
            M[i, j] = max;
        }
        public long Solve(string expression)
        {
            string[] a = expression.Select(s => s.ToString()).ToArray();
            List<string> op = new List<string>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == "+" || a[i] == "-" || a[i] == "*")
                {
                    op.Add(a[i]);
                    a[i] = "";
                }
            }

            string new_expression = String.Join("", a);
            long len = new_expression.Length;
            long[,] M = new long[len, len];
            long[,] m = new long[len, len];
            for (long z = 0; z < len; z++)
            {
                M[z, z] = Int64.Parse(new_expression[(int)z].ToString());
                m[z, z] = Int64.Parse(new_expression[(int)z].ToString());
            }

            for (long s = 1; s < len; s++)
            {
                for (long z = 0; z < len - s; z++)
                {
                    long j = z + s;
                    GetMinMax(op, z, j, new_expression, M, m);
                }
            }
            return M[0, len - 1];
        }
}