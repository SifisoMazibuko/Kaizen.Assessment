using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AssessmentC
    {
        [TestMethod]
        [TestCategory("Program.GetFirstEvenValue")]
        public void FirstOrDefaultUsed()
        {
            var value = Program.GetFirstEvenValue(new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 
            });
            Trace.TraceInformation("Value: {0}", value);
            Assert.IsTrue(value%2 == 0, "Indicates whether the use made use of the correct logic");
        }

        [TestMethod]
        [TestCategory("Program.SingleOrDefaultUsed")]
        public void SingleOrDefaultUsed()
        {
            string value = Program.GetSingleStringValue(new List<string>()
            {
               "John", "Jane", "Sarah", "Pete", "Anna"
            });

            Trace.TraceInformation("Testing for: System.InvalidOperationException: Sequence contains no elements");
            Trace.TraceInformation("Value: {0}", value);

            string value2 = Program.GetSingleStringValue(new List<string>()
            {
                "John", "Jane", "Sarah", "Pete"
            });

            Assert.IsTrue(!string.IsNullOrEmpty(value2));
        }
    }
}
