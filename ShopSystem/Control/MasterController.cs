using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using ShopSystem.Model;
using ShopSystem.View;

namespace ShopSystem.Control
{
    internal class MasterController
    {
        private List<Item> _catalog;
        private List<Account> _accounts;

        public MasterController() 
        {
            init();
        }


        private void init()
        {
            //string path = "files/accounts.json";
            //Directory.CreateDirectory("files");
            //List<Account> accounts = new List<Account>() { new Account("Test", "123")
            //    , new Account("Test2", "321")};
            //string json = JsonSerializer.Serialize(accounts);
            //File.WriteAllText(path, json);

            string path = "files/accounts.json";
            string output = File.ReadAllText(path);
            _accounts = JsonSerializer.Deserialize<List<Account>>(output)
                ?? new List<Account>();

            //string pathItems = "files/items.json";
            //List<Item> catalog = new List<Item>() { new Item("Test", 13.5)
            //    , new Item("Test2", 20, "This is a test")};
            //string jsonItems = JsonSerializer.Serialize(catalog);
            //File.WriteAllText(pathItems, jsonItems);

            string pathItems = "files/items.json";
            string outputItems = File.ReadAllText(pathItems);
            _catalog = JsonSerializer.Deserialize<List<Item>>(outputItems) 
                ?? new List<Item>();


        }

        public List<Account> Accounts()
        { return _accounts; }
        public List<Item> Catalog()
        { return _catalog; }
    }
}
