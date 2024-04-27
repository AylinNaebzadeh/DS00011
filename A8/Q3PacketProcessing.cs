using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Buffer
    {
        public long size {get; set;}
        public List<long> finish_time = new List<long>();


        // output the processing start time for each packet
        public long Process(long[] request)
        {

            while(finish_time.Count != 0 && finish_time[0] <= request[0])
            {
                finish_time.Remove(finish_time[0]);
            }
            if (finish_time.Count == 0)
            {
                finish_time.Add(request[1] + request[0]);
                return request[0];
            }
            else if(finish_time.Count < size)
            {
                finish_time.Add(request[1] + finish_time.Last());
                return finish_time[finish_time.Count - 2];
            }

            return  -1;
        } 
    }
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {
            // ExcludeTestCases(22);
            // ExcludeTestCases(23);
            // ExcludeTestCases(24);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);
        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            long count = arrivalTimes.Length;
            var buffer = new Buffer();
            buffer.size = bufferSize;
            long[] output = new long[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = buffer.Process(new long[]{arrivalTimes[i], processingTimes[i]});
            }
            return output;
        }
    }
}