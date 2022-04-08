using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Example.BusinessLogic;

namespace Example.Tests.TestMethods
{
    public class MathTestBL
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSum()
        {
            var mathBL = new MathService();
            int result = mathBL.Sum(2, 3);
            Assert.IsTrue(result == 5);
        }
    }
}
