using System;
using System.Collections.Generic;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class AddGarnishMenuItem : MenuItem
    {
        private Burger _burger;
        private Order _order;
        private List<Garnish> _garnishes;
       
        public AddGarnishMenuItem(Order order, List<Garnish> garnishes, Burger burger)
        {
            _order = order;
            _garnishes = garnishes;
            _burger = burger;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Select()
        {
            while (true)
            {
                Console.WriteLine("Garnishes:");
                for (int i = 0; i < _garnishes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_garnishes[i].Name} - £{_garnishes[i].Price}");
                }
                Console.Write("Enter garnish number (or 0 to finish): ");
                int garnishNumber = ConsoleHelpers.GetIntegerInRange(0, _garnishes.Count, "Enter garnish number") - 1;
                if (garnishNumber == -1)
                {
                    break;
                }
                Garnish garnish = _garnishes[garnishNumber];
                _burger.AddGarnish(garnish);
                Console.WriteLine($"Added garnish: {garnish.Name} - £{garnish.Price} to order");
                Console.WriteLine("Current order:");
                foreach (FoodItem foodItem in _order.AllFoodItems)
                {
                    Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                }
            }
        }

        public override string MenuText()
        {
            return "Add Garnish";
        }
    }
}