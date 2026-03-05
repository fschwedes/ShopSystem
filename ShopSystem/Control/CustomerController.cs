using ShopSystem.Model;
using ShopSystem.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Control
{
    internal class CustomerController
    {
        public void InitializeCustomerCatalog()
        {
            CustomerView customerView = new CustomerView();
            MasterController masterController = new MasterController();

            customerView.InitializeView();

            foreach (Item item in masterController.Catalog())
            {
                customerView.ShowItem(item.Name, item.Price);
            }
        }
    }
}
