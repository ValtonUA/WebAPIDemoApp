using DemoAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DemoAPI.Tests
{
    [TestClass]
    public class TextFileLoggerTest
    {
        [TestMethod]
        public void Instance_Get2Instances_ReturnsSameInstances()
        {
            TextFileLogger.CreateInstance("test");

            var instance1 = TextFileLogger.GetInstance();
            var instance2 = TextFileLogger.GetInstance();

            Assert.AreSame(instance1, instance2);
            instance1.TestField++;
            Assert.AreEqual(instance1.TestField, instance2.TestField);
            instance2.TestField++;
            Assert.AreEqual(instance1.TestField, instance2.TestField);
        }
    }
}
