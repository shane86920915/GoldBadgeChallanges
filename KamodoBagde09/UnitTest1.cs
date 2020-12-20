using KamodoBadge07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KamodoBagde09
{
    [TestClass]
    public class UnitTest1
    {

        BadgeRepo _badgerepo;
        Badge badge;
        Badge badge1;
        [TestInitialize]
        public void Arrange()
        {
            _badgerepo = new BadgeRepo();
            badge = new Badge(01, new List<string> { "A1", "B2" });
            badge1 = new Badge(01, new List<string> { "A1", "B2","C7" });
            _badgerepo.CreateBadge(badge);
            _badgerepo.CreateBadge(badge1);
            
        }

        [TestMethod]
        public void TestMethod1_createbadge()
        {
            int expected = 3;
           Badge badge2 = new Badge(01, new List<string> {  "B2", "C7" });
            _badgerepo.CreateBadge(badge2);

            Assert.AreEqual(expected, _badgerepo.GetBadges().Count);
        }

        [TestMethod]
        public void MyTestMethod_getbadges()
        {
            int expected = 2;
            Assert.AreEqual(expected, _badgerepo.GetBadges().Count);
        }

        [TestMethod]
        public void MyTestMethod_EditBadge()
        {
            Badge badge = new Badge(1000, new List<string> { "zoom317"});
            bool IsSuccessful = _badgerepo.EditBadge(1, badge);
            Console.WriteLine(badge.BadgeID);
            foreach (var door in badge.DoorNames)
            {

                Console.WriteLine(door);
            }
            Assert.IsTrue(IsSuccessful);

        }
        
    }
}
