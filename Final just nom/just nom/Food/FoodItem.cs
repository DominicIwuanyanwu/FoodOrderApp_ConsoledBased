using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{


    internal abstract class FoodItem
    {
        public  string Name { get; set; }

        public double Price { get; set; }

        public List <Topping> Toppings { get; set; }

        public List <Garnish> Garnishes { get; set; }

        public FoodItem (string _name, double _price)
        {
            Name = _name;
            Price = _price;
            Toppings = new List<Topping>();
            Garnishes = new List<Garnish>();
        }



        /// <summary>
        /// abstract method that calculates the price of all food items
        /// </summary>
        /// <returns> the total price calculated </returns>
        public abstract double CalculatingThePrice();
    }
}
