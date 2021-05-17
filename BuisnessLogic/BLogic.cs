using System;
using System.Collections.Generic;
using Models;
using DataLogic;

namespace BuisnessLogic
{
    public class BLogic
    {
        private storeDB _DB;
        private int _CustID;
        public BLogic(storeDB DB)
        {
            _DB = DB;
        }
        public void LocationHolderFunc(string name)
        {
            // find the location and info
            System.Console.WriteLine(name);
        }

        public void CheckUserCredentials(string email, string password){
            _CustID = _DB.GetUserID(email, password);
        }

        public void AddNewUser(string name, string email, string password){
            _CustID = _DB.AddUser(name, email, password);
            if(!(_CustID > 0)) throw new Exception("Unable to verify user creation");
        }
        public void ViewInventory()
        {
            
        }

        public void AddInventory()
        {

        }

        public void ViewTransactionsByCustomer()
        {
            _DB.GetCustomerOrderAndDetails(_CustID);
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
            _DB.SellItems(productId, orderAmount, _CustID);
        }
 
    }
}