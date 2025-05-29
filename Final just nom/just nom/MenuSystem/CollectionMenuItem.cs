using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class CollectionMenuItem : MenuItem
    {
        private List<Order> orders;

        public CollectionMenuItem(List<Order> orders)
        {
            this.orders = orders;
        }
        public override void Select()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("There are no orders available for delivery. Please place an order first.");
                return;
            }

            foreach (Order order in orders)
            {
                Console.WriteLine("Order found!");
                Console.WriteLine($"Hi {order.NameOfCustomer}, here are the details of your order:");

                foreach (FoodItem foodItem in order.AllFoodItems)
                {
                    if (foodItem is Pizza)
                    {
                        Pizza pizza = (Pizza)foodItem;
                        Console.WriteLine($"- {pizza.Name}: £{pizza.CalculatingThePrice()}");
                        if (pizza.Toppings.Count > 0)
                        {
                            Console.WriteLine("  Toppings:");
                            foreach (Topping topping in pizza.Toppings)
                            {
                                Console.WriteLine($"    - {topping.Name}: £{topping.Price}");
                            }
                        }
                    }
                    else if (foodItem is Burger)
                    {
                        Burger burger = (Burger)foodItem;
                        Console.WriteLine($"- {burger.Name}: £{burger.CalculatingThePrice()}");
                        if (burger.Garnishes.Count > 0)
                        {
                            Console.WriteLine("  Garnishes:");
                            foreach (Garnish garnish in burger.Garnishes)
                            {
                                Console.WriteLine($"    - {garnish.Name}: £{garnish.Price}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                    }
                }

                Console.WriteLine($"Total: £{order.CalculatingTotalPrice()}");

                Console.WriteLine("Would you like to save your order to a file");

                int input = ConsoleHelpers.GetIntegerInRange(0, 1, "Press 1 to save and 0 to exit");
                if (input == 0)
                {
                    continue;
                }
                else if (input == 1)
                {
                    order.SaveOrderToFile($"order_{order.NameOfCustomer}.txt");

                    Console.WriteLine($"Your order has been saved to order_{order.NameOfCustomer}.txt");
                }
            }

            orders.Clear();
            Console.WriteLine("You have successfully collected your order!");
        }



        public override string MenuText()
        {
            return "Collect your order";
        }
    }
}
