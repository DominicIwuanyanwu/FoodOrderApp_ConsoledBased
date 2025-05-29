using System;
using System.Collections.Generic;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class AddBurgerMenuItem : MenuItem
    { 
        private Order _order;
        private List<RecipeForBurger> _recipes;
        

        public AddBurgerMenuItem(Order order)
        {
            _order = order;
            _recipes = new List<RecipeForBurger>()
            {
                new RecipeForBurger("Sunflower Burger", 8.00, new List<Garnish> { new Garnish("Lettuce", 0.60), new Garnish("Tomato", 0.50) }),
                new RecipeForBurger("Cheese Burger", 9.00, new List<Garnish> { new Garnish("Cheese", 0.60), new Garnish("Tomato", 0.50), new Garnish("Cheddar Cheese", 1.00) }),
                new RecipeForBurger("Bacon Burger", 10.00, new List<Garnish> { new Garnish("Lettuce", 0.60), new Garnish("Tomato", 0.50), new Garnish("Bacon", 1.50) })
            };
        }


        public override void Select()
        {
            Console.WriteLine("Burgers:");
            for (int i = 0; i < _recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_recipes[i].Name} - £{_recipes[i].Price}");
            }
            Console.Write("Enter burger number (or 0 to finish): ");
            int burgerNumber = ConsoleHelpers.GetIntegerInRange(0, _recipes.Count, "Enter burger number") - 1;
            if (burgerNumber == -1)
            {
                return;
            }
            RecipeForBurger recipe = _recipes[burgerNumber];
            Burger burger = new Burger(recipe.Name, recipe.Price);
            _order.AllFoodItems.Add(burger);

            Console.WriteLine("Current order:");
            foreach (FoodItem foodItem in _order.AllFoodItems)
            {
                Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
            }
            ConsoleMenu menu = new GarnishMenu(burger, _order);
            menu.Select();
            
        }

        public override string MenuText()
        {
            return "Add Burger";
        }
    }
}