using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{
    internal class RecipeForBurger : Recipe 
    {
        public List <Garnish> Garnishes { get; set; }

        public RecipeForBurger (string Name, double Price, List <Garnish> Garnishes ) : base (Name, Price)
        {
            Garnishes = this.Garnishes;
        }
    }
}
