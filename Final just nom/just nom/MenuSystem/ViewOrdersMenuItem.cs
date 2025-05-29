using System;
using just_nom.Food;
using just_nom.MenuSystem;


namespace just_nom.MenuSystem
{
    internal class ViewOrdersMenuItem : MenuItem
    {
        private List<Order> _orders;


        public ViewOrdersMenuItem(List<Order> orders)
        {
            _orders = orders;
        }

        public override void Select()
        {
            if (_orders.Count == 0)
            {
                Console.WriteLine("There are no orders to view.");
            }
            else
            {
                foreach (Order order in _orders)
                {
                    Console.WriteLine("Order");
                    
                    Console.WriteLine($"Hi {order.NameOfCustomer}, here are the details of your order:"); 
                    double totalOrderValue = 0;
                    foreach (FoodItem foodItem in order.AllFoodItems)
                    {
                        Console.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                        totalOrderValue += foodItem.CalculatingThePrice();
                        if (foodItem is Pizza pizza)
                        {
                            if (pizza.Toppings.Count == 0)
                            {
                                Console.WriteLine("No toppings on this pizza yet!");
                            }
                            else
                            {
                                Console.WriteLine("  Toppings:");
                                foreach (Topping topping in pizza.Toppings)
                                {
                                    Console.WriteLine($"    - {topping.Name}: £{topping.Price}");
                                }
                            }
                           
                        }
                        if (foodItem is Burger burger)
                        {

                            if (burger.Garnishes.Count == 0)
                            {
                                Console.WriteLine("No Garinshes on this burger yet!");
                            }
                            else
                            {
                                Console.WriteLine(" Garnishes:");
                                foreach (Garnish garnish in burger.Garnishes)
                                {
                                    Console.WriteLine($"    - {garnish.Name}: £{garnish.Price}");
                                }
                            }
                           
                        }
                    }
                    Console.WriteLine($"Total order value: £{totalOrderValue}");
                }
            }
        }


        public override string MenuText()
        {
            return "View Orders";
        }

    }

}
