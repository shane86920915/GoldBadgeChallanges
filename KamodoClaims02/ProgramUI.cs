using KamodoClaims01;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KamodoClaims02
{
    public class ProgramUI
    {
        private readonly ClaimsRepo _Claimsrepo = new ClaimsRepo();

        public void Run()
        {
            SeedClaims();
            Claims();
        }
        private void Claims()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please choose a menu optoin. \n" +
                    "1. See all claims. \n" +
                    "2. Take care of next claim. \n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbuy");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void EnterANewClaim()
        {
            Console.Clear();
            Claims claims = new Claims();
            
            Console.WriteLine("Please enter a ClaimId.");
            var inputClaimId = Console.ReadLine();
            try 
	        {	        
		       int inputClaimIdAsInt = int.Parse(inputClaimId)
	        }
	         catch (FormatException)
	        {

	        	Console.WriteLine("Invalid input: Only numbers are allowed!");
	        	
	        }
            claims.ClaimID = inputClaimId;

            Console.WriteLine("Please make a selection\n" +
                "1.Car\n" +
                "2.Home\n" +
                "3.Theft\n");

            var inputSelection = int.Parse(Console.ReadLine());
            var inputClaimsType = (ClaimsType)inputSelection;
            claims.ClaimType = inputClaimsType;

            Console.WriteLine("Please enter a Claim description.");
            var inputClaimDescription = Console.ReadLine();
            claims.Description = inputClaimDescription;

            Console.WriteLine("Please enter a Claim amount.");
            var inputClaimAmount = decimal.Parse(Console.ReadLine());
            claims.ClaimAmount = inputClaimAmount;

            claims.DateOfIncident = GetADate("Date of Incident");
            claims.DateOfClaim = GetADate("Date of Claim");

            claims.IsValid = _Claimsrepo.IsValidClaim(claims.DateOfIncident, claims.DateOfClaim);

            if (claims.IsValid)
            {
                Console.WriteLine("Valid Claim");
            }
            else
            {
                Console.WriteLine("Invalid Claim");
            }

            _Claimsrepo.AddClaimsToqueue(claims);
        }

        DateTime GetADate(string message)
        {
            Console.WriteLine($"********{message}*************");

            Console.WriteLine("Please enter a Year.");
            var inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a Month.");
            var inputMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a Day.");
            var inputDay = int.Parse(Console.ReadLine());


            var dateTime = new DateTime(inputYear, inputMonth, inputDay);

            return dateTime;
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
           
           Claims claim= _Claimsrepo.ViewNextClaim();
            if (claim != null)
            {
                ViewClaimInfo(claim);

                Console.WriteLine("Do you want to handle this claim? y/n");
                string inputHandleClaim = Console.ReadLine();
               
                if (inputHandleClaim == "Y" || inputHandleClaim == "y")
                {
                    _Claimsrepo.RemoveClaimItemFromList();
                }
                if (inputHandleClaim == "N" || inputHandleClaim == "n")
                {
                    Claims();
                }
            }
            else
            {
                Console.WriteLine("Sorry there are no more claims in the queue.");
            }

        }

        //helper method
        private void ViewClaimInfo(Claims claims)
        {
            Console.WriteLine($"{claims.ClaimID}\n" +
                              $"{claims.ClaimType}\n" +
                              $"{claims.ClaimAmount}\n" +
                              $"{claims.Description}\n" +
                              $"{claims.DateOfIncident}\n" +
                              $"{claims.DateOfClaim}\n" +
                              $"{claims.IsValid}\n" +
                              $"*********************\n");
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> claims = _Claimsrepo.GetClaimsQueue();
            foreach (var claim in claims)
            {
                ViewClaimInfo(claim);
            }
        }
        private void SeedClaims()
        {
            Claims claims1 = new Claims(1, ClaimsType.Car, "465...", 4000.00m, new DateTime(2020, 04, 12), new DateTime(2020, 05, 07), true);
            Claims claims2 = new Claims(1, ClaimsType.Home, "House...", 4000.00m, new DateTime(2020, 04, 12), new DateTime(2020, 07, 07), false);
            Claims claims3 = new Claims(1, ClaimsType.Theft, "Theft...", 5000.00m, new DateTime(2020, 04, 12), new DateTime(2020, 05, 07), true);

            _Claimsrepo.AddClaimsToqueue(claims1);
            _Claimsrepo.AddClaimsToqueue(claims2);
            _Claimsrepo.AddClaimsToqueue(claims3);
        
        }
    }
}







    






