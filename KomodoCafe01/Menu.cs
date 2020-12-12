using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe01
{
    public class Menu
    {
       



        
        public int OrderNumber { get; set; }
        public string  MealName { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public string Description { get; set; }
        public decimal  Price { get; set; }

        public Menu()
        {

        }
        
        public  Menu (int ordernumber, List<string > listofingredients, string description, decimal price, string  mealName )
        {
            OrderNumber = ordernumber;
       
            ListOfIngredients = listofingredients;
            Description = description;
            Price = price;
            MealName = mealName;


        }


    }
}
