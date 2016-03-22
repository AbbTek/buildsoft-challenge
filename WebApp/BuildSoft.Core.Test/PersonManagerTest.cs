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
        public void TestGetPeople()
        {
            //Action
            var list1 = PersonManager.GetPeople(1, 10, PersonType.Angle);
            var list2 = PersonManager.GetPeople(2, 10, PersonType.Asian);
            var list3 = PersonManager.GetPeople(3, 10, PersonType.Jute);
            var list4 = PersonManager.GetPeople(3, 10, PersonType.Saxon);

            //Assert
            Assert.IsTrue(list1.TotalPeople > 2200);
            Assert.IsTrue(list2.TotalPeople > 2200);
            Assert.IsTrue(list3.TotalPeople > 2200);
            Assert.IsTrue(list4.TotalPeople > 2200);
        }

        [TestMethod]
        public void TestGetConsolidatedData()
        {
            //Action
            var dic = PersonManager.GetConsolidatedData();

            //Assert
            Assert.IsTrue(dic[PersonType.Angle] > 2200);
            Assert.IsTrue(dic[PersonType.Asian] > 2200);
            Assert.IsTrue(dic[PersonType.Jute] > 2200);
            Assert.IsTrue(dic[PersonType.Saxon] > 2200);
        }
    }
}
