using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{
    internal class Burger : FoodItem
    {
        public Burger(string Name, double Price) : base(Name, Price) { }

        /// <summary>
        /// Calculates the total price of all food items
        /// </summary>
        /// <returns>The total price of all the Food Items</returns>
        public override double CalculatingThePrice()
        {
            double TotalPrice = Price; // used to ensure that price is not null before assigning it to TotalPrice

            foreach (Garnish garnish in Garnishes)
            {
                TotalPrice += garnish.Price;
            }
            return TotalPrice;   // this returns the total price of the toppings 
        }

       
        /// <summary>
        /// adds garnish to burger 
        /// </summary>
        /// <param name="garnish"></param>
        public void AddGarnish(Garnish garnish)  
        {
            if (!Garnishes.Contains(garnish))
            {
                Garnishes.Add(garnish);
            }
        }



        /// <summary>
        /// removes garnish from burger
        /// </summary>
        /// <param name="garnish"></param>
        public void RemoveGarnish(Garnish garnish)  // for removing a garnish
        {
            if (Garnishes.Contains(garnish))
            {
                Garnishes.Remove(garnish);
            }
        }
    }
}
