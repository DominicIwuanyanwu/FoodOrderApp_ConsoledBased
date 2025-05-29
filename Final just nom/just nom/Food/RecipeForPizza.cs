using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{
    internal class RecipeForPizza : Recipe 
    {
        public List<Topping> Toppings { get; set; }

        public RecipeForPizza(string Name, double Price, List<Topping> Toppings) : base(Name, Price)
        {
            Toppings = this.Toppings;
        }

    }
}
