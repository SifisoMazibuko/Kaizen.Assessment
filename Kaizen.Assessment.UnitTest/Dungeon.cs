using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    public class Dungeon
    {
        [TestMethod]
        public void InvokeLvlAExtensionMethod()
        {
            MethodInfo methodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });

            Assert.IsTrue(methodInfo != null, "Indicates whether the extension method has not been implemented");

            IEnumerable<char> result = methodInfo.Invoke(typeof(Program), new object[] { "asduqwezxc" }) as IEnumerable<char>;

            Assert.IsNotNull(result, "Specifies whether the correct values has been returned");

            foreach (var item in result)
            {
                Trace.TraceInformation("-> {0}", item);
            }
        }

        [TestMethod]
        public void InvokeLvlB1ExtensionMethod()
        {
            Trace.TraceInformation("Ignore InvokeLvlB2ExtensionMethod, if this test succeeds!!");

            MethodInfo methodInfo = typeof (Program).GetMethod("CustomWhere");
            Assert.IsNotNull(methodInfo);
            MethodInfo generic = methodInfo.MakeGenericMethod(typeof(Dog));
            Assert.IsTrue(methodInfo != null, "Indicates whether the CustomWhere extension method has not been implemented");

            MethodInfo selectMethodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });
            Assert.IsTrue(selectMethodInfo != null, "Indicates whether the SelectOnlyVowels extension method has not been implemented");

            //Func<Dog, bool> expressionB = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

            Expression<Func<Dog, bool>> expression = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

            IEnumerable<Dog> dogs = new List<Dog>
            {
                new Dog {Age = 8, Name = "Max"},
                new Dog {Age = 3, Name = "Rocky"},
                new Dog {Age = 1, Name = "Cooper"},
                new Dog {Age = 5, Name = "Olivier"},
                new Dog {Age = 11, Name = "Teddy"},
                new Dog {Age = 9, Name = "XML"}
            };

            var result = generic.Invoke(typeof(Program), new object[] { dogs, expression }) as IEnumerable<Dog>;

            Assert.IsTrue(result != null && result.Count().Equals(2));
        }

        [TestMethod]
        public void InvokeLvlB2ExtensionMethod()
        {
            Trace.TraceInformation("If InvokeLvlB1ExtensionMethod fails, this method must succeed, else all possible answers are wrong");

            MethodInfo methodInfo = typeof(Program).GetMethod("CustomWhere");
            Assert.IsNotNull(methodInfo);
            MethodInfo generic = methodInfo.MakeGenericMethod(typeof(Human));
            Assert.IsTrue(methodInfo != null, "Indicates whether the CustomWhere extension method has not been implemented");

            MethodInfo selectMethodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });
            Assert.IsTrue(selectMethodInfo != null, "Indicates whether the SelectOnlyVowels extension method has not been implemented");

            Func<Human, bool> expressionB = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

            IEnumerable<Human> dogs = new List<Human>
            {
                new Human {Age = 8, Name = "Max"},
                new Human {Age = 3, Name = "Rocky"},
                new Human {Age = 1, Name = "Cooper"},
                new Human {Age = 5, Name = "Olivier"},
                new Human {Age = 11, Name = "Teddy"},
                new Human {Age = 9, Name = "XML"}
            };

            var result = generic.Invoke(typeof(Program), new object[] { dogs, expressionB }) as IEnumerable<Human>;

            Assert.IsTrue(result != null && result.Count().Equals(2));
        }
    }
}
