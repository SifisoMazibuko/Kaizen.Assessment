﻿using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentH
    {
        [TestMethod]
        public void ReflectionTest()
        {
            var withReflection = Program.CallMethodWithReflection();
            Assert.IsTrue(!string.IsNullOrEmpty(withReflection), "Indicates whether the method was implemented correctly");                        
        }
    }
}
