using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using just_nom.Food;

namespace just_nom.MenuSystem
{
    internal class LoadMenu : ConsoleMenu
    {
      

        public LoadMenu()
        {
            IsActive = true;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
           // _menuItems.Add(new LoadPizzaRecipes());
           // _menuItems.Add(new LoadBurgerRecipes());
           _menuItems.Add(new ExitMenuItem(this));
        }


        public override string MenuText()
        {
            return "Load Menu";
        }

       
        
      
        
    }
        
}
