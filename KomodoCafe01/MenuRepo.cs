using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe01
{
     public  class MenuRepo
    {   
       
        protected  readonly List<Menu> _MenuContent = new List<Menu>();

      
         public void AddMenuItemToList(Menu menuitem)
        {
            _MenuContent.Add(menuitem);

        }
        public List<Menu> GetMenuList()
        {
            return _MenuContent;
        }

        public bool RemoveMenuItemFromList(int mealId)
        {
            var menuItem = GetMenuItemById (mealId);

            if (menuItem == null)
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
        //helper Method
        public Menu GetMenuItemById(int MenuNumber)
        {
            foreach (var menuItem in _MenuContent)
            {
                if (menuItem.OrderNumber == MenuNumber)
                {
                    return menuItem;
                }
            }
            Console.WriteLine("There is no menu item with that name.");
            return null;
        }

    }
}
