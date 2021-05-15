using System;
using BuisnessLogic;

namespace UI.Menus
{
    public class SelectedStoreMenu
    {
        public void Start(LocationLogic LL)
        {
            Console.WriteLine("[0] View Inventory");
            Console.WriteLine("[1] Add Inventory");
            Console.WriteLine("[2] View Transcations");
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    LL.ViewInventory();
                    break;
                case "1": 
                    LL.AddInventory();
                    break;
                case "2": 
                    LL.ViewTransactions();
                    break;
                default:
                    Console.WriteLine("invalid input");
                    this.Start(LL);
                    break;
            }
        }

    }
}