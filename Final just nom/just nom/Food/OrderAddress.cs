using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;  //for the regex __ validating the code 

namespace just_nom.Food
{
    internal class OrderAddress
    {
        public string Address { get; set; }
        public string Telephone { get; set; }

        public OrderAddress(string address, string telephone)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(address))
                {
                    Console.WriteLine("Address cannot be null or whitespace. Please enter a valid address:");
                    address = Console.ReadLine();
                    continue;
                }

                if (!IsValidAddress(address))
                {
                    Console.WriteLine("Invalid address format. Please enter a valid address (at least one number, 3-50 characters):");
                    address = Console.ReadLine();
                    continue;
                }

                if (string.IsNullOrWhiteSpace(telephone))
                {
                    Console.WriteLine("Telephone cannot be null or whitespace. Please enter a valid telephone number:");
                    telephone = Console.ReadLine();
                    continue;
                }

                if (!IsValidTelephone(telephone))
                {
                    Console.WriteLine("Invalid telephone number format. Please enter a valid telephone number (only numbers and +):");
                    telephone = Console.ReadLine();
                    continue;
                }

                break;
            }

            Address = address;
            Telephone = telephone;
        }


        /// <summary>
        /// Makes sures the address has a number and letters
        /// </summary>
        /// <param name="address"> address of the customer</param>
        /// <returns> what the address is supposed to be </returns>
        private bool IsValidAddress(string address)
        {
            var addressRegex = new Regex(@"^(?=.*\d)[a-zA-Z0-9\s,.-]{3,50}$");
            return addressRegex.IsMatch(address);
        }



        /// <summary>
        /// Makes sure the telephone number only contains numbers and a '+' sign
        /// </summary>
        /// <param name="telephone"> the customers telephone number </param>
        /// <returns> what the telephone number is supposed to be </returns>
        private bool IsValidTelephone(string telephone)
        { 
            var telephoneRegex = new Regex(@"^[+0-9]+$");
            return telephoneRegex.IsMatch(telephone);
        }
    }
}
