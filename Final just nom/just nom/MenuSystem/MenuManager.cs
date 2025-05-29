using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.MenuSystem
{
    internal class MenuManager : ConsoleMenu
    {
        public MenuManager() 
        {
            IsActive = true;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
       //   _menuItems.Add(new LoadMenu());
            _menuItems.Add(new PlaceOrder());
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Shop Main Menu";
        }


    }
}
