using KomodoCafe01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe02
{
    class ProgramUI
    {
        public MenuRepo _menurepo = new MenuRepo();

         private  readonly List<Menu> _MenuContent = new List<Menu>();
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
                Console.WriteLine("Select a menu option.\n" +
                    "1. Create a new menu item.\n" +
                    "2. Delete existing menu item.\n" +
                    "3. Display all menu items.\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {

                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DeleteExistingMenuItem();
                        break;
                    case "3":
                        DisplayAllMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;



                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }








        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter the order number for the meal:");

            string orderNumberAsString = Console.ReadLine();
            int orderNumberAsInt = int.Parse(orderNumberAsString);
            newMenuItem.OrderNumber = orderNumberAsInt;

            Console.WriteLine("Enter the list of ingredients:");
            // newMenuItem.ListOfIngredients;
            string userinput = Console.ReadLine();
            newMenuItem.ListOfIngredients.Add(userinput);// need to create an if statement. 
            Console.WriteLine("Would you like do add an ingredient ");//create if in loop

            Console.WriteLine("Enter the description of the menu item:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the price of the item:");

            string priceAsString = Console.ReadLine();
            decimal priceAsDecimal = int.Parse(priceAsString);
            newMenuItem.Price = priceAsDecimal;

            Console.WriteLine("Enter the name of the meal:");
            newMenuItem.MealName = Console.ReadLine();



        }

        private void DeleteExistingMenuItem()
        {
            // DisplayAllMenuItems();

            Console.WriteLine("Enter the menu item you would like to remove:");
            string input = Console.ReadLine();
            bool wasdeleted = _menurepo.RemoveMenuItemFromList(input);

            if (wasdeleted)
            {
                Console.WriteLine("Menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Menu could not be deleted.");
            }




        }
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenuItem = _menurepo.getMenuList();
            Console.WriteLine("Display all memu items");
            foreach (Menu MenuItem in listOfMenuItem)
            {
                Console.WriteLine($"mealname:{MenuItem.MealName}\n" +
                    $"OrderNumber: #{MenuItem.OrderNumber}\n" +
                    $"price: ${MenuItem.Price}");


            }

        }
        private void Seedmenulist()
        {
            Menu SingleCheeseBurger = new Menu(1, new List<string> { "Hamburger", "Cheese", "Bun", "Pickle", "Mustard", "Ketchup" }, "Single Cheese burgar, Fries and a soft drink.", 5.32m, "Singal cheese burger meal");
            Menu Chickensandwich = new Menu(2, new List<string> { "Chicken Patty", "Bun", "Mayo", "Lettuce", "Tomatoe" }, "Grilled or fried chicken patty, Fries and a soft drink.", 6.55m, "chickensandwich meal");
            Menu Tenderloin = new Menu(3, new List<string> { "Tenderloin atty", "Bun", "Mayo", "Lettuce", "Tomatoe" }, "Tenderloin sandwich, Fries and a soft drink.", 8.93m, "Tenderloin meal");

           _menurepo.AddMenuItemToList(SingleCheeseBurger);//why does it return back
           _menurepo.AddMenuItemToList(Chickensandwich);
           _menurepo.AddMenuItemToList(Tenderloin);
        }











    }

}

