using ShopSystem.Control;

namespace ShopSystem.View
{
    internal class AdminView
    {
        private AdminController _adminController;
        public AdminView(AdminController adminController)
        {
            _adminController = adminController;
        }

        public void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("1: Edit Catalog");
            Console.WriteLine("2: Edit Users");
            _adminController.CheckInput(Console.ReadLine());
        }

        public void InvalidInput()
        {
            Console.WriteLine("\nInvalid Input! Press any key to continue");
            Console.ReadKey();
        }

        public void DisplayCatalog(List<string> entries)
        {
            Console.WriteLine("\nCurrent entries: ");
            foreach (string entry in entries)
            {
                Console.WriteLine(entries.IndexOf(entry) + "\t" + entry);
            }
            DisplayAddOrRemoveItem();
        }

        public void DisplayAddOrRemoveItem()
        {
            Console.WriteLine("\n'add' for new entry");
            Console.WriteLine("'remove' to delete entry");
            Console.WriteLine("'back' for main menu");
            _adminController.DoSomethingForCatalog(Console.ReadLine());
        }

        public void DisplayRemoveItemMessage()
        {
            Console.WriteLine("\nType in the index of the entry: ");
            _adminController.CatalogRemove(Console.ReadLine());
        }

        public void DisplayAddItemMessage()
        {
            string tempItemName;
            string tempItemPrice;
            string tempItemDescription;

            Console.Write("\nItemName: ");
            tempItemName = Console.ReadLine();
            Console.Write("ItemPrice: ");
            tempItemPrice = Console.ReadLine();
            Console.Write("ItemDescription: ");
            tempItemDescription = Console.ReadLine();

            _adminController.CatalogAdd(tempItemName, tempItemPrice, tempItemDescription);
        }

        public void DisplayUsers(List<string> entries)
        {
            Console.WriteLine("\nCurrent entries: ");
            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }
            DisplayAddOrRemoveUser();
        }

        public void DisplayAddOrRemoveUser()
        {
            Console.WriteLine("\n'add' for new entry");
            Console.WriteLine("'remove' to delete entry");
            Console.WriteLine("'back' for main menu");
            _adminController.DoSomethingForUsers(Console.ReadLine());
        }

        public void DisplayRemoveUserMessage()
        {
            Console.WriteLine("Type in the index of the entry (cannot delete other admins): ");
            _adminController.UserRemove(Console.ReadLine());
        }

        public void DisplayAddUserMessage()
        {
            string tempUserName;
            string tempUserPassword;
            string tempIsAdmin;

            Console.Write("UserName: ");
            tempUserName = Console.ReadLine();
            Console.Write("UserPassword: ");
            tempUserPassword = Console.ReadLine();
            Console.Write("IsAdmin (true/false): ");
            tempIsAdmin = Console.ReadLine();

            _adminController.UserAdd(tempUserName, tempUserPassword, tempIsAdmin);
        }
    }
}
