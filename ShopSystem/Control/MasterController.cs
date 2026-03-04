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
        }

        public List<Account> Accounts()
        { return _accounts; }
    }
}
