using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AdminController : MasterController
    {
        private AdminView _adminView;
        public AdminController()
        {
            _adminView = new AdminView(this);
            _adminView.DisplayOptions();
        }

        public void CheckInput(string input)
        {
            switch (input)
            {
                case "1":
                    EditCatalog();
                    break;
                case "2":
                    EditUsers();
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    _adminView.InvalidInput();
                    _adminView.DisplayOptions();
                    break;
            }
        }

        private void EditCatalog()
        {
            List<string> catalog = new List<string>();
            foreach (Item item in this.Catalog())
            {
                catalog.Add(item.ToString());
            }
            _adminView.DisplayCatalog(catalog);
        }

        public void DoSomethingForCatalog(string input)
        {
            switch (input.ToLower())
            {
                case "add":
                    _adminView.DisplayAddItemMessage();
                    break;
                case "remove":
                    _adminView.DisplayRemoveItemMessage();
                    break;
                case "back":
                    _adminView.DisplayOptions();
                    break;
                default:
                    _adminView.InvalidInput();
                    _adminView.DisplayAddOrRemoveItem();
                    break;
            }
        }

        public void CatalogAdd(string inputItemName, string inputItemPrice, string inputItemDescription)
        {
            double itemPrice;
            if (double.TryParse(inputItemPrice, out itemPrice))
            {
                this.Catalog().Add(new Item(inputItemName, itemPrice, inputItemDescription));
                _adminView.DisplayOptions();
            }
            else
            {
                _adminView.InvalidInput();
                _adminView.DisplayAddItemMessage();
            }
        }
        public void CatalogRemove(string input)
        {
            int index;
            if (int.TryParse(input, out index))
            {
                if (index <= this.Catalog().Count() || index >= 0)
                {
                    this.Catalog().RemoveAt(index);
                    _adminView.DisplayOptions();
                }
            }
            _adminView.InvalidInput();
            _adminView.DisplayRemoveItemMessage();
        }

        private void EditUsers()
        {
            List<string> accounts = new List<string>();
            foreach (Account account in this.Accounts())
            {
                accounts.Add(this.Accounts().IndexOf(account) + "\t" + account.ToString());
            }
            _adminView.DisplayUsers(accounts);
        }

        public void DoSomethingForUsers(string input)
        {
            switch (input.ToLower())
            {
                case "add":
                    _adminView.DisplayAddUserMessage();
                    break;
                case "remove":
                    _adminView.DisplayRemoveUserMessage();
                    break;
                case "back":
                    _adminView.DisplayOptions();
                    break;
                default:
                    _adminView.InvalidInput();
                    _adminView.DisplayAddOrRemoveUser();
                    break;
            }
        }

        public void UserAdd(string inputUserName, string inputUserPassword, string inputIsAdmin)
        {
            bool isAdmin;
            if (bool.TryParse(inputIsAdmin, out isAdmin))
            {
                this.Accounts().Add(new Account(inputUserName, inputUserPassword, isAdmin));
                _adminView.DisplayOptions();
            }
            else
            {
                _adminView.InvalidInput();
                _adminView.DisplayAddUserMessage();
            }
        }
        public void UserRemove(string input)
        {
            int index;
            if (int.TryParse(input, out index))
            {
                if (index >= 0 && index <= this.Accounts().Count()
                    && this.Accounts()[index].IsAdmin == false)
                {
                    this.Accounts().RemoveAt(index);
                    _adminView.DisplayOptions();
                }
            }
            _adminView.InvalidInput();
            _adminView.DisplayRemoveUserMessage();
        }
    }
}
