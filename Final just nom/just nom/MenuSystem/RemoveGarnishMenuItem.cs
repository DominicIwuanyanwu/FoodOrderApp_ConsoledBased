using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class RemoveGarnishMenuItem : MenuItem
    {
        private Burger _burger;
        private Order _order;
        private List<Garnish> _garnishes;

        public RemoveGarnishMenuItem(Order order, List<Garnish> garnishes, Burger burger)
        {
            _order = order;
            _garnishes = garnishes;
            _burger = burger;
        }

        public override void Select()
        {
            while (true)
            {
                if (_burger.Garnishes.Count == 0)
                {
                    Console.WriteLine("No garnishes to remove.");
                    break;
                }
                Console.WriteLine("Garnishes:");
                for (int i = 0; i < _burger.Garnishes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_burger.Garnishes[i].Name} - £{_burger.Garnishes[i].Price}");
                }
                Console.Write("Enter garnish number (or 0 to finish): ");
                int garnishNumber = ConsoleHelpers.GetIntegerInRange(0, _burger.Garnishes.Count, "Enter garnish number") - 1;
                if (garnishNumber == -1)
                {
                    break;
                }
                Garnish garnish = _burger.Garnishes[garnishNumber];
                _burger.RemoveGarnish(garnish);
                Console.WriteLine($"Removed garnish: {garnish.Name} - £{garnish.Price} from order");
                Console.WriteLine("Current order:");
                foreach (FoodItem foodItem in _order.AllFoodItems)
                {
                    Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                }
            }
        }


        public override string MenuText()
        {
            return "Remove Garnish";
        }
    }
}