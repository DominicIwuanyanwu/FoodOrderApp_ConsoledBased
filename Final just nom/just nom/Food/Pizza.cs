using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{
    internal class Pizza : FoodItem
    {
        public Pizza (string Name, double Price) : base (Name, Price) { }

        public Order Order { get; set; }

        /// <summary>
        /// Calculates the total price of all food items
        /// </summary>
        /// <returns>The total price of all the Food Items</returns>
        
        public override double CalculatingThePrice()
        {
            double TotalPrice = Price; // used to ensure that price is not null before assigning it to TotalPrice

            foreach (Topping topping in Toppings)
            {
                TotalPrice += topping.Price;
            }

            return TotalPrice; 
        }

        /// <summary>
        /// adds topping to the pizza
        /// </summary>
        /// <param name="garnish"></param>
        public void AddTopping(Topping topping)  // for adding a topping 
        {
            if (!Toppings.Contains(topping))
            {
                Toppings.Add(topping);
            }
        }

        /// <summary>
        /// removes topping from the pizza  
        /// </summary>
        /// <param name="garnish"></param>

        public void RemoveTopping(Topping topping)  // for removing a topping 
        {
            if (Toppings.Contains(topping))
            {
                Toppings.Remove(topping);
            }
        }
    }
}
