using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using just_nom.MenuSystem;

namespace just_nom.Food
{
    internal class OrderToBeDelivered : Order
    {
        public OrderAddress OrderAddress { get; set; }

        public double DeliveryCharge { get; set; }

        public OrderToBeDelivered(string NameOfCustomer, OrderAddress orderadress) : base(NameOfCustomer)
        {
            OrderAddress = orderadress;
            DeliveryCharge = 2.00;
        }

        /// <summary>
        /// Calculates the delivery charge 
        /// </summary>
        /// <returns> the delivery charge ... if the delivery is worth more than 20 pounds, the delivery is free </returns>
        public double CalculateTotalDeliveryPrice()
        {
            double TotalPrice = base.CalculatingTotalPrice(); //calls the calculateTotalPrice method in the base class 

            if (TotalPrice > 20.00)
            {
                DeliveryCharge = 0.00;
            }
            return TotalPrice + DeliveryCharge;
        }



        /// <summary>
        /// saves the delivery order to a file 
        /// </summary>
        /// <param name="fileName"> the name of the customer </param>
        public void SaveOrderToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Order for " + this.NameOfCustomer);
                writer.WriteLine("Food Items:");
                foreach (FoodItem foodItem in this.AllFoodItems)
                {
                    if (foodItem is Pizza)
                    {
                        Pizza pizza = (Pizza)foodItem;
                        writer.WriteLine($"- {pizza.Name}: £{pizza.CalculatingThePrice()}");
                        if (pizza.Toppings.Count > 0)
                        {
                            writer.WriteLine("  Toppings:");
                            foreach (Topping topping in pizza.Toppings)
                            {
                                writer.WriteLine($"    - {topping.Name}: £{topping.Price}");
                            }
                        }
                    }
                    else if (foodItem is Burger)
                    {
                        Burger burger = (Burger)foodItem;
                        writer.WriteLine($"- {burger.Name}: £{burger.CalculatingThePrice()}");
                        if (burger.Garnishes.Count > 0)
                        {
                            writer.WriteLine("  Garnishes:");
                            foreach (Garnish garnish in burger.Garnishes)
                            {
                                writer.WriteLine($"    - {garnish.Name}: £{garnish.Price}");
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine($"- {foodItem.Name}: £{foodItem.CalculatingThePrice()}");
                    }
                }

                writer.WriteLine($"Total: £{this.CalculatingTotalPrice()}");

                writer.WriteLine($"Address: {this.OrderAddress.Address}");
                writer.WriteLine($"Telephone: {this.OrderAddress.Telephone}");

                if (this.CalculatingTotalPrice() > 20)
                {
                    this.DeliveryCharge = 0;
                    writer.WriteLine($"Delivery Charge: £0 (free delivery on orders over £20)");
                }
                else
                {
                    writer.WriteLine($"Delivery Charge: £{this.DeliveryCharge}");
                }
          
                writer.WriteLine($"Total Delivery Price: £{this.CalculateTotalDeliveryPrice()}");
            }
        }
    }
}
