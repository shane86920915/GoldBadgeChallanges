using KomodoCafe01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe03
{
    [TestClass]
    public class MenuRepoTest
    {
        private MenuRepo _menurepo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _menurepo = new MenuRepo();
            _item = new Menu(1, new List<string> { "Hamburger", "Cheese", "Bun", "Pickle", "Mustard", "Ketchup" },
                "Single Cheese burgar, Fries and a soft drink.", 5.32m, "Singal cheese burger meal");

            _menurepo.AddMenuItemToList(_item);
        }
        [TestMethod]
        public void Testing()
        {
            int expected = 1;
            var originalList = _menurepo.GetMenuList(); //Create new list of type menu

            Assert.AreEqual(expected, originalList.Count);
        }

        [TestMethod]
        public void Addtolist_shouldnotnull()
        {
            List<Menu> listOfItem = new List<Menu>(); //Create new instance of menu list
            int listcount = listOfItem.Count; //counts number of items in menu list


            Menu menuItem = new Menu();

            //      MealName = "SingleCheeseBurger"

            MenuRepo repo = new MenuRepo();
            repo.AddMenuItemToList(menuItem);

            List<Menu> repoList = repo.GetMenuList();
            Assert.AreEqual(listcount + 1, repoList.Count);



        }
        //update
        /*[TestMethod]
        public void UpdateExistingContent()
        {

            _menurepo = new MenuRepo();
            Menu newMenu = new Menu(1, new List<string> { "Hamburger", "Cheese", "Bun", "Mayo", "Mustard", "Ketchup" },
                "Single Cheese burgar, onion rings and a soft drink.", 5.67m, "Singal cheese burger meal");
        bool UpdateResults = _menurepo.updateExistingMenuItems("Single cheese burger meal");

        }*/

        //act
        [TestMethod]
        public void RemoveMenuItem()
        {
            bool deleteMenuItem = _menurepo.RemoveMenuItemFromList(_item.MealName);
            Assert.IsTrue(deleteMenuItem);
        


        }




    }
}
