using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.MenuSystem
{
    internal class ExitMenuItem : MenuItem // abstract child of menu item , used to exit a from the menu when the select method in it is called  
    {
        private ConsoleMenu _menu;

        public ExitMenuItem(ConsoleMenu parentItem)
        {
            _menu = parentItem;
        }
        public override string MenuText()
        {
            return "Exit";
        }
        public override void Select()
        {
            _menu.IsActive = false;
        }

    }


}
