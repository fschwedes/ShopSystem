using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.View
{
    internal class CustomerView
    {
        public void InitializeView()
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
            Console.WriteLine("\n");
        }

        public void ShowItem(string itemName, double itemPrice, int itemNumber)
        {
            Console.Write(itemNumber + "  ");
            Console.Write("\t" + itemName);
            Console.Write("\t\t" + itemPrice);
            Console.WriteLine("\tEUR");
        }

        public string BuyInput()
        {
            string input;
            Console.Write("\nWhich item would you like to add to your shopping cart: ");
            input = Console.ReadLine();
            return input;
        }

        public string InvalidInput()
        {
            string input;
            Console.Write("Input was invalid! Please use the numbers of the products: ");
            input = Console.ReadLine();
            return input;
        }

        public void ShowShoppingCart()
        {
            Console.WriteLine("\n");
        }
    }
}
