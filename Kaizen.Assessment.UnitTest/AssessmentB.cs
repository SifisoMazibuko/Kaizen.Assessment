using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentB
    {
        [TestMethod]
        [Timeout(2000)]
        public void PerformanceTest()
        {
            // check whether the performance has increased
            Stopwatch s = new Stopwatch();
            s.Start();
            Program.PerformanceTest();
            s.Stop();
            Trace.TraceInformation("Performance: {0}ms", s.ElapsedMilliseconds);
            Assert.IsTrue(s.ElapsedMilliseconds < 1000, "Elapsed Milliseconds greater than 1 second indicates slow performance");
        }
    }
}