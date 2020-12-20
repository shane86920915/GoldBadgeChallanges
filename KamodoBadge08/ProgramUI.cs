using KamodoBadge07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamodoBadge08
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badges = new BadgeRepo();

        public void Run()
        {
            Seedmenulist();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. create a new badge\n" +
                    "2. update doors on an existing badge.\n" +
                    "3. show a list with all badge numbers and door access\n" +
                    "4.  Exit\n"
                    );
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateDoorsOnExistingBadge();
                        break;
                    case "3":
                        ListOfBadgeNumbersAndDoorAccess();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid opion.");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();


            }


        }

        private void CreateNewBadge()
        {
            Console.Clear();
            Badge newbadge = new Badge();

            Console.WriteLine("What is the number on the badge: ");
            newbadge.BadgeID = int.Parse(Console.ReadLine());
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("List a door that it needs access to:");
                newbadge.DoorNames.Add(Console.ReadLine());

                Console.WriteLine("Any other doors(Y/N)");
                string DoorNames = Console.ReadLine().ToLower();

                if (DoorNames == "y")
                {
                    keepRunning = true;

                }
                else if (DoorNames == "n")
                {
                    keepRunning = false;
                }


            }
            _badges.CreateBadge(newbadge);
        }



        public void UpdateDoorsOnExistingBadge()
        {
            Console.Clear();
            ListOfBadgeNumbersAndDoorAccess();
            Console.WriteLine("Please enter a valid key");
            var userinput = int.Parse(Console.ReadLine());
            Badge badge = _badges.GetBadgeByKey(userinput);
            Console.Clear();
            viewbadgeinfo(badge);
            
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove door.\n" +
                "2. Add a door.\n" +
                "3. Return to main menu.\n");
            var inputDoor = int.Parse(Console.ReadLine());
            
            switch (inputDoor)
            {
                case 1:
                    Console.WriteLine("Please input a door name to delete");
                    var inputDoorName = Console.ReadLine();
                    _badges.RemoveADoor(userinput, inputDoorName);
                    break;
                case 2:
                    AddADoor(badge);
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;

                default:
                    break;
            }
        }

        private void AddADoor(Badge newBadge)
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("List a door that it needs access to:");
                newBadge.DoorNames.Add(Console.ReadLine());

                Console.WriteLine("Any other doors(Y/N)");
                string DoorNames = Console.ReadLine().ToLower();

                if (DoorNames == "y")
                {
                    keepRunning = true;

                }
                else if (DoorNames == "n")
                {
                    keepRunning = false;
                }


            }
        }

        
    

        public void ListOfBadgeNumbersAndDoorAccess()
        {
            Console.Clear();
            var badges = _badges.GetBadges();
            foreach (var badge in badges)
            {
                Console.WriteLine($"Key: {badge.Key}");
                viewbadgeinfo(badge.Value);
            }
        }
        private void viewbadgeinfo(Badge badge)
        {
            Console.WriteLine($"{badge.BadgeID}");
            foreach (var door in badge.DoorNames)
            {
                Console.WriteLine(door);

            }
            Console.WriteLine("***********************");
        }

        private void Seedmenulist()
        {
            Badge badge1 = new Badge(01, new List<string> { "A1", "B2" });
            Badge badge2 = new Badge(01, new List<string> { "A2", "B1" });
            Badge badge3 = new Badge(01, new List<string> { "A3", "c1" });
            _badges.CreateBadge(badge1);
            _badges.CreateBadge(badge2);
            _badges.CreateBadge(badge3);
        }









    }
}
