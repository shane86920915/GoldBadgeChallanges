using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamodoClaims01
{
    public enum ClaimsType
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claims
    {

        public int ClaimID { get; set; }
        public ClaimsType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }
        public Claims()
        {

        }

        public Claims(int claimid, ClaimsType claimtype, string description, decimal claimamount, DateTime dateofincident, DateTime dateofclaim, bool isvalid)
        {
            ClaimID = claimid;
            ClaimType = claimtype;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
            IsValid = isvalid;



        }

    }

}












