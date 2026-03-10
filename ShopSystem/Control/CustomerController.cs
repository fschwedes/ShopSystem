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

        //bei initialisierung des customer-controllers wird die benutzeroblerfläche
            //geupdated und eine neue einkaufs-session gestarted
        public void Init()
        {
            Update();
            StartSession();

        }

        //aktualisierung der benutzeroberfläche
        private void Update()
        {
            _customerView.Header();
            DisplayShoppingCart();
            DisplayCatalog();
        }

        //session wird gestarted mit einer schleife die beendet wird sobald der kunde
            //exit schreibt und die gleichnamige methode wird ausgeführt
        //mit checkout wird ein beleg ausgegeben und der warenkorb geleert
        //bei eingeben der produktnummer wird diese zum warenkorb hinzugefügt
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

        //logik wie der katalog ausgegeben werden soll
        private void DisplayCatalog()
        {
            foreach (Item item in this.Catalog())
            {
                _customerView.ShowItem(item.Name, item.Price, this.Catalog().IndexOf(item));
            }
        }

        //logik wie der einkaufswagen ausgegeben werden soll
        private void DisplayShoppingCart()
        {
            _customerView.ShowShoppingCart(_shoppingCart.Count(), CalcTotalPrice());
        }

        //logik wie der gesamtpreis des einkaufswagens berechnet wird
        private double CalcTotalPrice()
        {
            double totalPrice = 0;

            foreach (Item item in _shoppingCart)
            {
                totalPrice += item.Price;
            }

            return totalPrice;
        }
    }
}
