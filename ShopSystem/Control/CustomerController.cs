using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class CustomerController : MasterController
    {
        private CustomerView _customerView;
        private List<Item> _shoppingCart;
        public CustomerController()
        {
            _customerView = new CustomerView(this);
            _shoppingCart = new List<Item>();
            Init();
        }
        public void Init()
        {
            Update();
            StartSession();

        }

        private void Update()
        {
            _customerView.Header();
            DisplayShoppingCart();
            DisplayCatalog();
        }

        private void StartSession()
        {
            string userInput;
            while (true)
            {
                userInput = _customerView.AwaitInput();

                if (userInput.ToLower() == "exit")
                {
                    break;
                }
                else if (userInput.ToLower() == "checkout")
                {
                    List<string> productNames = new List<string>();
                    List<double> productPrices = new List<double>();
                    foreach (Item item in _shoppingCart)
                    {
                        productNames.Add(item.Name);
                        productPrices.Add(item.Price);
                    }
                    _customerView.Checkout(productNames, productPrices, CalcTotalPrice());
                    _shoppingCart.Clear();
                    Update();
                }
                else
                {
                    try
                    {
                        int temp = int.Parse(userInput);
                        if (temp <= this.Catalog().Count() && temp > 0)
                        {
                            _shoppingCart.Add(this.Catalog()[temp - 1]);
                            Update();
                        }
                        else
                        {
                            _customerView.InvalidInput();
                        }

                    }
                    catch (Exception)
                    {

                        _customerView.InvalidInput();
                    }
                }
            }
            Exit();
        }

        private void DisplayCatalog()
        {
            foreach (Item item in this.Catalog())
            {
                _customerView.ShowItem(item.Name, item.Price, this.Catalog().IndexOf(item));
            }
        }
        private void DisplayShoppingCart()
        {
            _customerView.ShowShoppingCart(_shoppingCart.Count(), CalcTotalPrice());
        }

        private double CalcTotalPrice()
        {
            double totalPrice = 0;

            foreach (Item item in _shoppingCart)
            {
                totalPrice += item.Price;
            }

            return totalPrice;
        }

        //private int CheckBuyInput(CustomerView customerView, MasterController masterController)
        //{
        //    bool check = true;
        //    int orderNumber = 0;
        //    do
        //    {
        //        if (!check)
        //        {
        //            check = int.TryParse(customerView.InvalidInput(), out orderNumber);
        //        }
        //        else
        //        {
        //            check = int.TryParse(customerView.BuyInput(), out orderNumber);
        //        }

        //        if (orderNumber > masterController.Catalog().Count() || orderNumber < 1)
        //        {
        //            check = false;
        //        }

        //    }
        //    while (!check);
        //    return orderNumber - 1;
        //}

        //private double AddItemToShoppingCart(MasterController masterController, int orderNumber, int activeUser)
        //{
        //    Item currentOrder;
        //    currentOrder = masterController.Catalog()[orderNumber];
        //    masterController.Accounts()[activeUser].ShoppingCart.Add(currentOrder);
        //    return currentOrder.Price;
        //}
    }
}
