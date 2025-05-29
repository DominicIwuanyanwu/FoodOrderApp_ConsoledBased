using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class DeliveryMenuItem : MenuItem
    {
        private List<Order> orders;

        public DeliveryMenuItem(List<Order> orders)
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

            Console.WriteLine("Please enter the Address and Telephone number for the delivery:");
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Telephone: ");
            string telephone = Console.ReadLine();

            OrderAddress orderAddress = new OrderAddress(address, telephone);

            foreach (Order order in orders)
            {
                OrderToBeDelivered orderToBeDelivered = new OrderToBeDelivered(order.NameOfCustomer, orderAddress);

                Console.WriteLine("Order found!");
                Console.WriteLine($"Hi {order.NameOfCustomer}, here are the details of your order:");

                foreach (FoodItem foodItem in order.AllFoodItems)
                {
                    orderToBeDelivered.AllFoodItems.Add(foodItem);

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

                Console.WriteLine($"Total: £{orderToBeDelivered.CalculatingTotalPrice()}");

                Console.WriteLine($"Delivery Address: {orderToBeDelivered.OrderAddress.Address}");
                Console.WriteLine($"Telephone: {orderToBeDelivered.OrderAddress.Telephone}");


                if (orderToBeDelivered.CalculatingTotalPrice() > 20)
                {
                    orderToBeDelivered.DeliveryCharge = 0;
                    Console.WriteLine($"Delivery Charge: £0 (free delivery on orders over £20)");
                }
                else
                {
                    Console.WriteLine($"Delivery Charge: £{orderToBeDelivered.DeliveryCharge}");
                }

                Console.WriteLine($"Total Delivery Price: £{orderToBeDelivered.CalculateTotalDeliveryPrice()}");


                Console.WriteLine("Would you like to save your order to a file");

                int input = ConsoleHelpers.GetIntegerInRange(0, 1, "Press 1 to save and 0 to exit");
                if (input == 0)
                {
                    return;
                }
                else if (input == 1)
                {
                    orderToBeDelivered.SaveOrderToFile($"order_{order.NameOfCustomer}.txt");

                    Console.WriteLine($"Your order has been saved to order_{order.NameOfCustomer}.txt");
                }


               

            }

            orders.Clear(); // this clears all the list of orders after its been processed
            Console.WriteLine("All orders have been delivered successfully, thank you!"); 

        }

        public override string MenuText()
        {
            return "Get your order delivered";
        }

    }

}
