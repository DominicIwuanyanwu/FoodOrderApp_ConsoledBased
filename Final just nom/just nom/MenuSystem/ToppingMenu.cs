using System;
using just_nom.Food;
using just_nom.MenuSystem;



namespace just_nom.MenuSystem
{
    internal class ToppingMenu : ConsoleMenu
    {
        private Pizza _pizza;
        private List<Topping> _toppings;
        private Order _order;
        

        public ToppingMenu(Pizza pizza, Order order)
        {
            _pizza = pizza;
            _order = order;
            _toppings = new List<Topping>
        {
            new Topping("Pepperoni", 1.00),
            new Topping("Mushroom", 0.50),
            new Topping("Olives", 0.75),
            new Topping("Bacon", 1.25),
            new Topping("Peppers", 0.70),
        };
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddToppingMenuItem(_pizza, _toppings, _order));
           _menuItems.Add(new RemoveToppingMenuItem(_pizza, _toppings, _order));
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Topping Menu";
        }
    }


}