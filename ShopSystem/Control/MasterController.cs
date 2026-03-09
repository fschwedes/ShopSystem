using ShopSystem.Model;
using System.Text.Json;

namespace ShopSystem.Control
{
    internal class MasterController
    {
        private List<Item> _catalog;
        private List<Account> _accounts;
        private Account _activeUser;
        private AuthenticationController _authenticationController;
        private CustomerController _customerController;
        private AdminController _adminController;


        public MasterController()
        {
            init();
        }

        private void init()
        {
            //string path = "files/accounts.json";
            //Directory.CreateDirectory("files");
            //List<Account> accounts = new List<Account>() { new Account("Test", "123", false)
            //    , new Account("Test2", "321", true)};
            //string json = JsonSerializer.Serialize(accounts);
            //File.WriteAllText(path, json);

            string path = "files/accounts.json";
            string output = File.ReadAllText(path);
            _accounts = JsonSerializer.Deserialize<List<Account>>(output)
                ?? new List<Account>();

            //string pathItems = "files/items.json";
            //List<Item> catalog = new List<Item>() { new Item("Test", 13.5, "", 1)
            //    , new Item("Test2", 20, "This is a test", 2)};
            //string jsonItems = JsonSerializer.Serialize(catalog);
            //File.WriteAllText(pathItems, jsonItems);

            string pathItems = "files/items.json";
            string outputItems = File.ReadAllText(pathItems);
            _catalog = JsonSerializer.Deserialize<List<Item>>(outputItems)
                ?? new List<Item>();
        }

        public void Start()
        {
            _authenticationController = new AuthenticationController();

        }

        public void Login(Account activeUser)
        {
            _activeUser = activeUser;
            if (activeUser.IsAdmin == true)
            {
                _adminController = new AdminController();
            }
            else
            {
                _customerController = new CustomerController();
            }
        }

        public void Exit()
        {
            string pathAccounts = "files/accounts.json";
            //Directory.CreateDirectory("files");
            string jsonAccounts = JsonSerializer.Serialize(_accounts);
            File.WriteAllText(pathAccounts, jsonAccounts);

            string pathItems = "files/items.json";
            string jsonItems = JsonSerializer.Serialize(_catalog);
            File.WriteAllText(pathItems, jsonItems);
        }


        public List<Account> Accounts()
        { return _accounts; }
        public List<Item> Catalog()
        { return _catalog; }
        public Account ActiveUser()
        { return _activeUser; }
    }
}
