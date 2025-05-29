using System;
using System.Collections.Generic;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class GarnishMenu : ConsoleMenu
    {
        private Burger _burger;
        private Order _order;
        private List<Garnish> _garnishes;

        public GarnishMenu(Burger burger, Order order)
        {
            _order = order;
            _burger = burger;
            _garnishes = new List<Garnish>
        {
            new Garnish("Lettuce", 0.25),
            new Garnish("Tomato", 0.30),
            new Garnish("Cheese", 0.50),
            new Garnish("Bacon", 0.75),
            new Garnish("Hashbrown", 1.00),
        };
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddGarnishMenuItem( _order, _garnishes, _burger));
            _menuItems.Add(new RemoveGarnishMenuItem(_order, _garnishes, _burger));
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Garnish Menu";
        }
    }
}





