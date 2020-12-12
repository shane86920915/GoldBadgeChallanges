using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe01
{
     public  class MenuRepo
    {   
       
        private readonly List<Menu> _MenuContent = new List<Menu>();

        public void AddMenuItemToList(Menu menuitem)
        {
            _MenuContent.Add(menuitem);

        }

        public List<Menu> getMenuList()
        {
            return _MenuContent;
        }

        public bool RemoveMenuItemFromList(string mealName)
        {
            Menu menuItem = GetMenuItemByName(mealName);

            if (mealName == null)
            {
                return false;
            }
            int initialcount = _MenuContent.Count;
            _MenuContent.Remove(menuItem);

            if (initialcount > _MenuContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

          

            
        }

        public Menu GetMenuItemByName(string MealName)
        {
            foreach (Menu menuItem in _MenuContent)
            {
                if (menuItem.MealName == MealName)
                {
                    return menuItem;
                }
            }
            Console.WriteLine("There is no menu item with that name.");
            return null;






        }


    }
}
