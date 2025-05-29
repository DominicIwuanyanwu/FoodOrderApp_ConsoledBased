using System;
using System.Collections.Generic;
using just_nom.Food;

namespace just_nom.MenuSystem
{
    internal class AddPizzaMenuItem : MenuItem
    {
        private Order _order;
        private List<RecipeForPizza> _recipes;


        public AddPizzaMenuItem(Order order)
        {
            _order = order;
            _recipes = new List<RecipeForPizza>()  // creates a list of Pizzas 
            {
                new RecipeForPizza("Margherita pizza", 8.00, new List<Topping> { new Topping("Tomato sauce", 0.50), new Topping("Mozzarella", 1.00) }),
                new RecipeForPizza("Ham and Mushroom pizza", 9.00, new List<Topping> { new Topping("Tomato sauce", 0.50), new Topping("Mozzarella", 1.00), new Topping("Ham", 1.50), new Topping("Pineapple", 1.00) }),
                new RecipeForPizza("Meat Lover's pizza", 10.00, new List<Topping> { new Topping("Tomato sauce", 0.50), new Topping("Mozzarella", 1.00), new Topping("Pepperoni", 1.00), new Topping("Sausage", 1.50), new Topping("Bacon", 1.25) })
            }; 
        }

        public override void Select()
        {
            Console.WriteLine("Pizzas:");
            for (int i = 0; i < _recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_recipes[i].Name} - ${_recipes[i].Price}");
            }
            Console.Write("Enter pizza number (or 0 to finish): ");
            int pizzaNumber = ConsoleHelpers.GetIntegerInRange(0, _recipes.Count, "Enter pizza number") - 1; ;
            if (pizzaNumber == -1)
            {
                return;
            }
            RecipeForPizza recipe = _recipes[pizzaNumber];
            Pizza pizza = new Pizza(recipe.Name, recipe.Price);
            _order.AllFoodItems.Add(pizza);
            Console.WriteLine($"Added pizza: {pizza.Name} - £{pizza.CalculatingThePrice()}");
            Console.WriteLine("Current order:");
            foreach (FoodItem foodItem in _order.AllFoodItems)
            {
                Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
            }
            ConsoleMenu menu = new ToppingMenu(pizza,_order);
            menu.Select();
            // Create a new order
            Console.WriteLine("Order created.");
        }

        public override string MenuText()
        {
            return "Add Pizza";
        }
    }
}