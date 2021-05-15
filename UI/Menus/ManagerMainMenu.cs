using Models;
using System;
using BuisnessLogic;
using DataLogic; 

namespace UI.Menus
{
    public class ManagerMainMenu
    {
        public void Start(storeDB DB)
        {
            var bll = new BuisnessLogic.LocationLogic(DB);

            Console.WriteLine("[0] Find a Customer");
            Console.WriteLine("[1] Find an Order");
            Console.WriteLine("[2] Manage a Store Location");
            Console.WriteLine("[3] View All Locations");
            
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    CustomerFinder();
                    break;
                case "1":
                    OrderFinder();
                    break;
                case "2":
                    new StoreMenu().Start();
                    break;
                case "3":
                    bll.GetAllStores();
                    break;
                default:
                    this.Start(DB);
                    break;
            }
        }

        public void CustomerFinder()
        {
            System.Console.WriteLine("finding customer later");
        }

        public void OrderFinder()
        {
            System.Console.WriteLine("finding order");
        }

    }
}