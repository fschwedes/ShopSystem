using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Model
{
    internal class Item
    {
        private string _name;
        private string _description = "";
        private double _price;
        private int _itemNumber;

        //public Item(string name, double price) 
        //{
        //    _name = name;
        //    _price = price;
        //}
        public Item(string name, double price, string description, int itemNumber)
        {
            _name = name;
            _price = price;
            _description = description;
            _itemNumber = itemNumber;
        }

        public string Name { get => _name; }
        public double Price { get => _price; }
        public string Description { get => _description; }
        public int ItemNumber { get => _itemNumber; }
    }
}
