using KamodoClaims01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KamodoClaims03
{
   


    [TestClass]
    public class UnitTest1
    {
         ClaimsRepo _claimRepo;
        Claims claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimsRepo();
            claim = new Claims(1, ClaimsType.Car, 
                "465...", 4000.00m, 
                new DateTime(2020, 04, 12), 
                new DateTime(2020, 05, 07), true);
           
            _claimRepo.AddClaimsToqueue(claim);

        }

        [TestMethod]
        public void TestMethod1_AddClaimsToQueue()
        {
            int expected = 2;
           Claims claim2 = new Claims(1, ClaimsType.Car,
               "465...", 4000.00m,
               new DateTime(2020, 04, 12),
               new DateTime(2020, 05, 07), true);
            _claimRepo.AddClaimsToqueue(claim2);

            Assert.AreEqual(expected, _claimRepo.GetClaimsQueue().Count);
        }

        [TestMethod]
        public void MyTestMethod_GetClaimsQueue()
        {
            int expected = 1;
            Assert.AreEqual(expected, _claimRepo.GetClaimsQueue().Count);
        }

        [TestMethod]
        public void MyTestMethod_GetClaimsByID()
        {
            Claims claim2 = new Claims(3, ClaimsType.Car,
              "465...", 4000.00m,
              new DateTime(2020, 04, 12),
              new DateTime(2020, 05, 07), true);
          
            _claimRepo.AddClaimsToqueue(claim2);

            Claims claim = _claimRepo.GetClaimsItemByID(3);

            Assert.IsTrue(claim.ClaimAmount == 4000 && claim.ClaimID == 3);
            
        }


    }
}
