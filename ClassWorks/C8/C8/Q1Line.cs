using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C8
{
	public class Q1Line : Processor
	{
		public Q1Line(string testDataName) : base(testDataName) {}

		public override string Process(string inStr) => C8Processors.ProcessQ1Line(inStr, Solve);

		public string Solve(long n, long[][] p)
		{
			long maxCount = 0;
			for (long i = 0; i < p.Count(); i++)
			{
				long localMax = 0;
				long overLap = 1;
				long on_x = 1;
				SortedDictionary<double, long> sd = new SortedDictionary<double, long>();
				for (long j = i + 1; j < p.Count(); j++)
				{
					if (p[i][0] == p[j][0] && p[i][1] == p[j][1])
					{
						overLap++;
					}
					else if (p[i][0] == p[j][0])
					{
						on_x++;
					}
					else
					{
						double s = (double)(p[i][1] - p[j][1]) / (double) (p[i][0] - p[j][0]);
						if (sd.ContainsKey(s))
						{
							sd[s]++;
						}
						else
						{
							sd[s] = 1;
						}
					}
				}

				foreach(var s in sd.Keys)
				{
					localMax = Math.Max(sd[s], localMax);
				}
				maxCount = Math.Max(on_x, Math.Max(localMax + overLap, maxCount));
			}
			return maxCount.ToString();
		}
	}
}
