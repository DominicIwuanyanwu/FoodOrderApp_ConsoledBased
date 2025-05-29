using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class BurgerMenu : ConsoleMenu
    {
        private Order _order;
       

        public BurgerMenu(Order order)
        {
            _order = order;

        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddBurgerMenuItem (_order));
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Add Burger";
        }

    }

}