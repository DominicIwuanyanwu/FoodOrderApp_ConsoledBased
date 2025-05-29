using System;
using just_nom.Food;
using just_nom.MenuSystem;

internal class PizzaMenu : ConsoleMenu
{
    private Order _order;

    public PizzaMenu(Order order)
    {
        _order = order;
    }

    public override void CreateMenu()
    {
        _menuItems.Clear();
        _menuItems.Add(new AddPizzaMenuItem(_order));
        _menuItems.Add(new ExitMenuItem(this));
    }

    public override string MenuText()
    {
        return "Pizza Menu";
    }
}