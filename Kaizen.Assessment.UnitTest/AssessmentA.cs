using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AssessmentA
    {
        [TestMethod]
        [TestCategory("Human")]
        public void TestA1()
        {
            //Arrange 
            string name = "John";
            int age = 35;
            string gender = "M";

            //Act
            var human = new Human()
            {
                Name = name,
                Age = age,
                Gender = gender
            };
            //Assert
            Assert.AreNotSame(typeof(Human), typeof(Human).BaseType);
        }

        [TestMethod]
        [TestCategory("Human")]
        public void TestA2()
        {
            Assert.IsTrue(typeof(Human).BaseType.IsAbstract,"Error thrown for false condition");
        }

        [TestMethod]
        public void TestA3()
        {
            //Arrange 
            string name = "John";
            int age = 35;
            string gender = "M";

            //Act
            var human = new Human()
            {
                Name = name,  Age = age,  Gender = gender
            };
            //Assert
            Assert.AreSame(typeof(Human).GetMethod("GetDetails").DeclaringType, typeof(Human));
           
        }

        [TestMethod]
        public void TestA4()
        {
            
            Assert.AreNotSame(typeof(Human), typeof(Human).BaseType);

           // Assert.AreSame(typeof(Human).BaseType.GetMethod("GetDetails").DeclaringType, typeof(Human).BaseType);
        }

        [TestMethod]
        public void TestA5()
        {
            //Arrange 
            var properties = typeof (Human).BaseType.GetProperties().ToList();

             
            //Assert.IsTrue(properties.Count < 0);

            Assert.IsTrue(properties.FirstOrDefault(x => x.Name.Equals("Name")) == null);
            Assert.IsTrue(properties.FirstOrDefault(x => x.Name.Equals("Age")) == null);
        }

        [TestMethod]
        public void ABonus1()
        {
            var baseType = typeof (Human).BaseType;
            Assert.IsTrue(baseType != null);
            {
                var interfaces = baseType.GetInterfaces();
                Assert.IsTrue(interfaces != null && interfaces.Any());
            }
        }
    }
}
