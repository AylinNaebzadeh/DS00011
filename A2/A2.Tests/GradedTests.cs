using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            var rnd = new Random();
            Stopwatch s = new Stopwatch();
            s.Start();
            while(s.Elapsed < TimeSpan.FromSeconds(5))
            {
                int n = rnd.Next(2, 10);
                var myarray = new long[n];
                for (int i = 0; i < n; i++)
                {
                    myarray[i] = rnd.Next(0, 100);
                }
                var q1_object = new Q1NaiveMaxPairWise("TD1");
                var q2_object = new Q2FastMaxPairWise("TD2");

                var q1_solve = q1_object.Solve(myarray);
                var q2_solve = q2_object.Solve(myarray);

                if (q1_solve == q2_solve)
                {
                    Assert.AreEqual(q1_solve, q2_solve,"Everything is working fine.");
                }

                else
                {
                    Assert.AreNotEqual(q1_solve, q2_solve,$"The resualt of Q1NaiveMaxPairWise is {q1_solve}  and the resualt of Q2FastMaxPairWise is {q2_solve}");
                    return;
                }
            }
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}