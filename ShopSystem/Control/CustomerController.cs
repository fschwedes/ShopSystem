using ShopSystem.Model;
using ShopSystem.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Control
{
    internal class CustomerController : MasterController
    {
        public void InitializeCustomerCatalog(int activeUser)
        {
            CustomerView customerView = new CustomerView();
            MasterController masterController = new MasterController();
            int orderNumber;

            customerView.InitializeView();

            foreach (Item item in masterController.Catalog())
            {
                customerView.ShowItem(item.Name, item.Price, item.ItemNumber);
            }

            orderNumber = CheckBuyInput(customerView, masterController);
        }

        private int CheckBuyInput(CustomerView customerView, MasterController masterController)
        {
            bool check = true;
            int orderNumber = 0;
            do
            {
                if (!check)
                {
                    check = int.TryParse(customerView.InvalidInput(), out orderNumber);
                }
                else
                {
                    check = int.TryParse(customerView.BuyInput(), out orderNumber);
                }

                if (orderNumber > masterController.Catalog().Count() || orderNumber < 1)
                {
                    check = false;
                }

            }
            while (!check);
            return orderNumber;
        }

        private void AddItemToShoppingCart()
        {

        }
    }
}
