using System;
using System.Collections.Generic;
using Models;
using DataLogic;

namespace BuisnessLogic
{
    public class BLogic
    {
        private storeDB _DB;
        public BLogic(storeDB DB)
        {
            _DB = DB;
        }
        public void LocationHolderFunc(string name)
        {
            // find the location and info
            System.Console.WriteLine(name);
        }
        public void ViewInventory()
        {
            
        }

        public void AddInventory()
        {

        }

        public void ViewTransactions()
        {

        }

        public void GetAllStores()
        {
            Console.Clear();
            _DB.GetAllLocations().ForEach(i => Console.WriteLine(i.Name+" Location \nAddress:\n"+i.Address+"\n"));
        }

        public int CheckItemAmount1(int productId)
        {
            return _DB.CheckItemAmount(productId);
        }

        public double GetProductPrice(int productId)
        {
            return _DB.GetProductInfo(productId).Price;
        }

        public void MakePurchase(int productId, int orderAmount)
        {
            _DB.SellItems(productId, orderAmount);
        }
 
    }
}