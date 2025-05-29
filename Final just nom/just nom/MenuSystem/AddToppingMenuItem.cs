using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class AddToppingMenuItem : MenuItem
    {

        private Pizza _pizza;
        private List<Topping> _toppings;
        private Order _order;

        public AddToppingMenuItem(Pizza pizza, List<Topping> toppings, Order order)
        {
            _pizza = pizza;
            _toppings = toppings;
            _order = order;
          
        }

        public override void Select()
        {
            while (true)
            {
                Console.WriteLine("Toppings:");
                for (int i = 0; i < _toppings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_toppings[i].Name} - £{_toppings[i].Price}");
                }
                Console.Write("Enter topping number (or 0 to finish): ");
                int toppingNumber = ConsoleHelpers.GetIntegerInRange(0, _toppings.Count, "Enter topping number") - 1;
                if (toppingNumber == -1)
                {
                    break;
                }
                Topping topping = _toppings[toppingNumber];
                _pizza.AddTopping(topping);
                Console.WriteLine($"Added topping: {topping.Name} - £{topping.Price} to {_pizza.Name}");
                Console.WriteLine("Current order:");
                foreach (FoodItem foodItem in _order.AllFoodItems)
                {
                    Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                }
            }
        }

        public override string MenuText()
        {
            return "Add Topping";
        }
    }
}

