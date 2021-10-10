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
                Console.WriteLine("Select a menu opti(;" +
                    "on.\n" +
                    "1. Create a new menu item.\n" +
                    "2. Delete existing menu item.\n" +
                    "3. Display all menu items.\n" +
                    "4. Display a single menu item\n" +
                    "5. Exit");
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
                        DisplayMenuItemDetails();
                        break;
                    case "5":
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

            //create the name...
            Console.WriteLine("Enter the name of the meal:");
            var userInputMealName = Console.ReadLine();
            newMenuItem.MealName = userInputMealName;

            string userinput;
            bool ison = true;
            while (ison)
            {
                Console.WriteLine("Would you like do add an ingredient  Y/N ");//create if in loop
                userinput = Console.ReadLine();
                if (userinput.ToLower() == "y")
                {
                    Console.WriteLine("Enter an  ingredient:");

                    userinput = Console.ReadLine();
                    newMenuItem.ListOfIngredients.Add(userinput); 
                }
                else if (userinput.ToLower() == "n")
                {
                    ison = false;
                }
            }
            
            Console.WriteLine("Enter the description of the menu item:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the price of the item:");

            string priceAsString = Console.ReadLine();
            decimal priceAsDecimal = int.Parse(priceAsString);
            newMenuItem.Price = priceAsDecimal;

            _menurepo.AddMenuItemToList(newMenuItem);
        }

        private void DeleteExistingMenuItem()
        {
             DisplayAllMenuItems();
            Console.WriteLine("*****************************\n\n");
            Console.WriteLine("Enter the menu item orderId you would like to remove:");
            int input = int.Parse(Console.ReadLine());
            Menu item = _menurepo.GetMenuItemById(input);
            Console.Clear();
            DisplayMenuItemDetails(item);
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
            List<Menu> listOfMenuItem = _menurepo.GetMenuList();
            Console.WriteLine("Display all memu items");

            foreach (Menu MenuItem in listOfMenuItem)
            {
                DisplayMenuItemDetails(MenuItem);
            }
            Console.WriteLine("\n");
        }

        private void DisplayMenuItem()
        {
            Console.Clear();
         
            Console.WriteLine("please enter a menu number.");
           
            string variableIdAsString = Console.ReadLine();
            int variableIdAsInt = int.Parse(variableIdAsString);

            var menuItem = _menurepo.GetMenuItemById(variableIdAsInt);
            DisplayMenuItemDetails(menuItem);
           
            
        }

        private void DisplayMenuItemDetails(Menu menuItem)
        {
            Console.WriteLine($"OrderNumber:{menuItem.OrderNumber}\n" +
                    $"MealName: #{menuItem.MealName}\n" +
                    $"Description: { menuItem.Description}\n" +
                    $"Price: {menuItem.Price}\n");

            Console.WriteLine("***************Ingredients*********************");
      
            foreach (var ing in menuItem.ListOfIngredients)
            {
                Console.WriteLine($"ing: {ing}");
            }
            Console.WriteLine("************************************");

        }
        private void SeedmenuList()
        {
            Menu SingleCheeseBurger = new Menu(1, new List<string> { "Hamburger", "Cheese", "Bun", "Pickle", "Mustard", "Ketchup" }, "Single Cheese burgar, Fries and a soft drink.", 5.32m, "Singal cheese burger meal");
            Menu Chickensandwich = new Menu(2, new List<string> { "Chicken Patty", "Bun", "Mayo", "Lettuce", "Tomatoe" }, "Grilled or fried chicken patty, Fries and a soft drink.", 6.55m, "chickensandwich meal");
            Menu Tenderloin = new Menu(3, new List<string> { "Tenderloin atty", "Bun", "Mayo", "Lettuce", "Tomatoe" }, "Tenderloin sandwich, Fries and a soft drink.", 8.93m, "Tenderloin meal");

            _menurepo.AddMenuItemToList(SingleCheeseBurger);
            _menurepo.AddMenuItemToList(Chickensandwich);
            _menurepo.AddMenuItemToList(Tenderloin);
        }
    }
}

