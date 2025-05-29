using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
	internal class RemoveToppingMenuItem : MenuItem
	{
        private Pizza _pizza;
        private List<Topping> _toppings;
        private Order _order;

        public RemoveToppingMenuItem(Pizza pizza, List<Topping> toppings, Order order)
        {
            _pizza = pizza;
            _toppings = toppings;
            _order = order;

        }
 

       public override void Select()
       {
            while (true)
            {
                if (_pizza.Toppings.Count == null)
                {
                    Console.WriteLine($" No toppings to remove.");
                }
                else
                {
                    Console.WriteLine($"Current toppings on {_pizza.Name}:");
                    for (int i = 0; i < _pizza.Toppings.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {_pizza.Toppings[i].Name} - £{_pizza.Toppings[i].Price}");
                    }
                    Console.Write("Enter topping number (or 0 to finish): ");
                    int toppingNumber = ConsoleHelpers.GetIntegerInRange(0, _pizza.Toppings.Count, "Enter topping number") - 1;
                    if (toppingNumber == -1)
                    {
                        break;
                    }
                    Topping topping = _pizza.Toppings[toppingNumber];
                    _pizza.RemoveTopping(topping);
                    Console.WriteLine($"Removed topping: {topping.Name} - £{topping.Price} from {_pizza.Name}");
                    Console.WriteLine("Current order:");
                    foreach (FoodItem foodItem in _order.AllFoodItems)
                    {
                        Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                    }
                }
            }
       }
    

        public override string MenuText()
        {
            return "Remove Topping";
        }
    }
}

