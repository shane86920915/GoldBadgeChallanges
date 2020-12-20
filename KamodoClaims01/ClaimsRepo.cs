using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamodoClaims01
{
   public class  ClaimsRepo


    {
       private readonly  Queue<Claims> ClaimsQueue = new Queue<Claims>();

     
        /*For #1, a claims agent could see all items in the queue listed out like this:

ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid
1	Car	Car accident on 465.	$400.00	4/25/18	4/27/18	true
2	Home	House fire in kitchen.	$4000.00	4/11/18	4/12/18	true
3	Theft	Stolen pancakes.	$4.00	4/27/18	6/01/18	false
For #2, when a claims agent needs to deal with an item they see the next item in the queue.*/
       


     
        public void AddClaimsToqueue(Claims claimsitem)
        {
            ClaimsQueue.Enqueue(claimsitem);

        }

        public Queue<Claims> GetClaimsQueue()
        {
            return ClaimsQueue;

        }
        public bool UpdateClaimsItem(int OriginalID, Claims NewClaimsItem)
        {
            Claims OldClaimsItem = GetClaimsItemByID(OriginalID);
            if (OldClaimsItem != null)
            {
                OldClaimsItem.ClaimID = NewClaimsItem.ClaimID;
                OldClaimsItem.ClaimType = NewClaimsItem.ClaimType;
                OldClaimsItem.ClaimAmount = NewClaimsItem.ClaimAmount;
                OldClaimsItem.DateOfIncident = NewClaimsItem.DateOfIncident;
                OldClaimsItem.DateOfClaim = NewClaimsItem.DateOfClaim;
                OldClaimsItem.IsValid = NewClaimsItem.IsValid;
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool RemoveClaimItemFromList()
        {

            if (ClaimsQueue.Count >0)
            {
                ClaimsQueue.Dequeue();
                return true;
            }
            return false;

        }
        public Claims GetClaimsItemByID(int ClaimID)
        {
            foreach (Claims claimsItem in ClaimsQueue) 
            {
                if (claimsItem.ClaimID == ClaimID)
                {
                    return claimsItem;
                }
            }
            Console.WriteLine("There are currently no claims associated with that ID number...");
            return null;


        }

        public Claims ViewNextClaim()
        {
            if (ClaimsQueue.Count>0)
            {
                Claims claims = ClaimsQueue.Peek();
                return claims;
            }
            return null;
        }

        public bool IsValidClaim(DateTime dateOfIncident, DateTime dateOfClaim)
        {
            var ans = dateOfClaim - dateOfIncident;
            var comparison = TimeSpan.FromDays(ans.Days);
            Console.WriteLine(comparison.Days);
            if (comparison.Days<=30 && comparison.Days>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}