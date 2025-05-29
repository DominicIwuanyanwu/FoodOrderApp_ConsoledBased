using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
	internal class PlaceOrder : ConsoleMenu
	{
        private List<Order> orders;

        public PlaceOrder()
        {
            IsActive = true;

           orders = new List<Order> (); 
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new CreateOrder(orders));
            _menuItems.Add(new ViewOrdersMenuItem(orders));
            _menuItems.Add(new DeliveryMenuItem(orders));
            _menuItems.Add(new CollectionMenuItem(orders));
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Place Order";
        }
    }
}
