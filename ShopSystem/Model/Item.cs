using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Model
{
    //model-klasse die informationen enthält aber keine logische verarbeitung der informationen
    internal class Item
    {
        private string _name;
        private string _description = "";
        private double _price;

        public Item(string name, double price, string description)
        {
            _name = name;
            _price = price;
            _description = description;
        }

        //überschreibung der ToString methode um ein für den user lesbaren output zu bekommen
        public override string ToString()
        {
            return $"{_name} | {_price} | {_description}";
        }

        public string Name { get => _name; }
        public double Price { get => _price; }
        public string Description { get => _description; }
    }
}
