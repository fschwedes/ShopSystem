using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class AdminController : MasterController
    {
        private AdminView _adminView;

        //bei instanziierung des admin controllers wird auch ein neues admin-view instanziiert
            //und die methode DisplayOptions wird gestartet
        public AdminController()
        {
            _adminView = new AdminView(this);
            _adminView.DisplayOptions();
        }

        //überprüfung der eingabe mit switch für verschiedene fälle
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

        //---------------------------------------------------------------------
        //methode falls der katalog geändert werden soll
        //alle einträge dessen werden jeweils in einem string angezeigt
        private void EditCatalog()
        {
            List<string> catalog = new List<string>();
            foreach (Item item in this.Catalog())
            {
                catalog.Add(item.ToString());
            }
            _adminView.DisplayCatalog(catalog);
        }

        //abfrage was der admin mit dem katalog machen möchte mit switch
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

        //überprüfung und logik der benutzereingabe um einen eintrag zum katalog hinzuzufügen
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

        //überprüfung und logik der benutzereingabe um einen eintrag des katalogs zu entfernen
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
        //---------------------------------------------------------------------


        //---------------------------------------------------------------------
        //methode falls die accounts geändert werden sollen
        //alle einträge dessen werden jeweils in einem string angezeigt
        private void EditUsers()
        {
            List<string> accounts = new List<string>();
            foreach (Account account in this.Accounts())
            {
                accounts.Add(this.Accounts().IndexOf(account) + "\t" + account.ToString());
            }
            _adminView.DisplayUsers(accounts);
        }

        //abfrage was der admin mit den accounts machen möchte über switch
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

        //überprüfung und logik der benutzereingabe um einen eintrag zu accounts hinzuzufügen
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

        //überprüfung und logik der benutzereingabe um einen eintrag von accounts zu entfernen
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
        //---------------------------------------------------------------------
    }
}
