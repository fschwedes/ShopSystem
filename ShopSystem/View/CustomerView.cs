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

        public void ShowItem(string itemName, double itemPrice)
        {
            Console.Write("\t" + itemName);
            Console.WriteLine("\t\t" + itemPrice);
        }
    }
}
