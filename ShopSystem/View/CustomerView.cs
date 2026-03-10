using ShopSystem.Control;

namespace ShopSystem.View
{
    internal class CustomerView
    {
        private CustomerController _controller;
        public CustomerView(CustomerController controller)
        {
            _controller = controller;
        }
        public void Header()
        {
            Console.Clear();
            Console.WriteLine("\t-----Shop-----");
        }

        public void ShowItem(string itemName, double itemPrice, int index)
        {
            Console.Write(index + 1 + "  ");
            Console.Write("\t" + itemName);
            Console.Write("\t\t" + itemPrice);
            Console.WriteLine("\tEUR");
        }

        public void InvalidInput()
        {
            Console.Write("Input was invalid! Please use the numbers of the products!");
        }

        public void ShowShoppingCart(int itemCount, double totalPrice)
        {
            Console.WriteLine();
            Console.WriteLine($"Products in your shopping-cart: {itemCount}");
            Console.WriteLine($"Total: {totalPrice} EUR");
            Console.WriteLine();
        }

        public string AwaitInput()
        {
            Console.WriteLine();
            Console.Write("Which item do you want to purchase (product numbers only): ");
            return Console.ReadLine();
        }

        public void Checkout(List<string> productNames, List<double> productPrices, double total)
        {
            Console.WriteLine("\nYour shopping-cart: \n");
            for (int i = 0; i < productNames.Count(); i++)
            {
                Console.WriteLine($"\t{productNames[i]}\t{productPrices[i]} EUR");
            }
            Console.WriteLine($"\n\tTotal: {total} EUR");
            Console.ReadLine();
        }

    }
}
