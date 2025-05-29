using System;
using just_nom.Food;
using just_nom.MenuSystem;

namespace just_nom.MenuSystem
{
    internal class CreateOrder : MenuItem
    {
       
        private List<Order> _orders;

        public CreateOrder(List<Order> orders)
        {
            _orders = orders;
        }

        public override void Select()
        {
            string customerName;
            while (true)
            {
                Console.WriteLine("What is your name?");
                customerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(customerName))
                {
                    Console.WriteLine("The name cannot be empty. Please try again.");
                }
                else if (!IsValidName(customerName))
                {
                    Console.WriteLine("A name can only contain letters and spaces. Please try again.");
                }
                else
                {
                    break;
                }
            }

            Order order = new Order(customerName);
            _orders.Add(order);

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add a pizza to your order");
                Console.WriteLine("2. Add a burger to your order");
                Console.WriteLine("3. Return to main menu");

                int option = ConsoleHelpers.GetIntegerInRange(1, 5, "Enter option");

                switch (option)
                {
                    case 1:
                        ConsoleMenu menu = new PizzaMenu(order);
                        menu.Select();
                        break;
                    case 2:
                        menu = new BurgerMenu(order);
                        menu.Select();
                        break;
                    case 3:
                        return;  // Return to main menu
                }
            }
        }


        private bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        public override string MenuText()
        {
            return "Create Order";
        }


    }






}

