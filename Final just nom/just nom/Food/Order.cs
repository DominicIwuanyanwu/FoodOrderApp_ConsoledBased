using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{
    internal class Order
    {
        public string NameOfCustomer { get; set; }

        public List<FoodItem> AllFoodItems { get; set; }

        public Order(string _NameOfCustomer)
        {
            NameOfCustomer = _NameOfCustomer;

            AllFoodItems = new List<FoodItem>();
        }


        /// <summary>
        /// Calculates the total price of all food items
        /// </summary>
        /// <returns>The total price of all the Food Items</returns>


        public double CalculatingTotalPrice()
        {
            double TotalPrice = 0;

            foreach (FoodItem foodItem in AllFoodItems)
            {
                TotalPrice += foodItem.CalculatingThePrice();
            }
            return TotalPrice;

        }


           
        /// <summary>
        /// saves the order for collection to a file 
        /// </summary>
        /// <param name="fileName"> name of the customer </param>
        
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
            }
        }
        
    }

}