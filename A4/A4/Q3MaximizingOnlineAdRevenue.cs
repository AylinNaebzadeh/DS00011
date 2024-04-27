using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            long res = 0;
            for (int i = 0; i < slotCount; i++)
            {
                for (int j = i + 1; j < slotCount; j++)
                {
                    if (adRevenue[i] < adRevenue[j])
                    {
                        long tmp = adRevenue[i];
                        adRevenue[i] = adRevenue[j];
                        adRevenue[j] = tmp;
                    }
                }
            }

            for (int i = 0; i < slotCount; i++)
            {
                for (int j = i + 1; j < slotCount; j++)
                {
                    if (averageDailyClick[i] < averageDailyClick[j])
                    {
                        long tmp = averageDailyClick[i];
                        averageDailyClick[i] = averageDailyClick[j];
                        averageDailyClick[j] = tmp;
                    }
                }
            }

            for (int i = 0; i < slotCount; i++)
            {
                res += Convert.ToInt64(adRevenue[i]) * Convert.ToInt64(averageDailyClick[i]);
            }
            return res;
        }
    }
}
