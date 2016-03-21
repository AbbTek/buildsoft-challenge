using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSoft.Core.Business;
using System.Linq;
using BuildSoft.Core.Domain;

namespace BuildSoft.Core.Test
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        public void TestInit()
        {
            //Action
            var list = PersonManager.Init();

            //Assert
            var angles = list.Where(x => x.GetType() == typeof(Angle)).Count();
            var asians = list.Where(x => x.GetType() == typeof(Asian)).Count();
            var jutes = list.Where(x => x.GetType() == typeof(Jute)).Count();
            var saxons = list.Where(x => x.GetType() == typeof(Saxon)).Count();

            var total = angles + asians + jutes + saxons;
            //It should be a similar number of objects for each type
            Assert.IsTrue(angles > 2200);
            Assert.IsTrue(asians > 2200);
            Assert.IsTrue(jutes > 2200);
            Assert.IsTrue(saxons > 2200);
            Assert.AreEqual(10000, total);
        }
    }
}
