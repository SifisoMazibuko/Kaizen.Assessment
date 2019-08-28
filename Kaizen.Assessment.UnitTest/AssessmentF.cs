using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentF
    {
        [TestMethod]
        public void InvokeGenericMethodA()
        {
            MethodInfo method = typeof(Program).GetMethod("ShowSomeMammalInformation");

            Assert.IsTrue(method != null, "Indicates whether the generic method has not been implemented");

            Human human = new Human()
            {
                Name = "John Doe", Age = 34
            };
            Dog dog = new Dog()
            {
                Name = "Russell",
                Age = 7
            };
            Cat cat = new Cat()
            {
                Name = "Mr.. Whiskers",
                Age = 5
            };

            MethodInfo generic = method.MakeGenericMethod(typeof(Human));
            generic.Invoke(typeof(Program), new object[] { human });
            
            generic = method.MakeGenericMethod(typeof(Dog));
            generic.Invoke(typeof(Program), new object[] { dog });
            
            generic = method.MakeGenericMethod(typeof(Cat));
            generic.Invoke(typeof(Program), new object[] { cat });
        }

        [TestMethod]
        public void InvokeGenericMethodB()
        {
            MethodInfo method = typeof(Program).GetMethod("GenericTester");
            Assert.IsTrue(method != null, "Indicates whether the generic method has not been implemented");

            Human human = new Human()
            {
                Name = "John Doe", Age = 34
            };

            Dog dog = new Dog()
            {
                Name = "Walter", Age = 7
            };

            Func<Dog, string> func1 = x => x.GetDetails();
            Type[] typeArgs1 = { typeof(Dog), typeof(string) };
            MethodInfo generic1 = method.MakeGenericMethod(typeArgs1);
            var resultA = generic1.Invoke(typeof(Program), new object[]
            {
                func1, dog
            });
            Trace.TraceInformation("{0}", resultA);            

            Func<Human, string> func2 = x => x.GetDetails();
            Type[] typeArgs2 = { typeof(Human), typeof(string) };
            MethodInfo generic2 = method.MakeGenericMethod(typeArgs2);
            var resultB = generic2.Invoke(typeof(Program), new object[]
            {
                func2, human
            });
            Trace.TraceInformation("{0}", resultB);

            Type[] typeArgs3 = { typeof(Human), typeof(string) };
            MethodInfo generic3 = method.MakeGenericMethod(typeArgs3);
            var resultC = generic3.Invoke(typeof(Program), new object[]
            {
                func2, null
            });
            Trace.TraceInformation("{0}", resultC);
        }
    }
}
