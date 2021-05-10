using System;

namespace UI.Menus
{
    public class SelectedStoreMenu
    {
        public void Start()
        {
            Console.WriteLine("[0] View Inventory");
            Console.WriteLine("[1] Add Inventory");
            Console.WriteLine("[2] View Transcations");
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    ViewInventory();
                    break;
                case "1": 
                    AddInventory();
                    break;
                case "2": 
                    ViewTransactions();
                    break;
                default:
                    Console.WriteLine("invalid input");
                    this.Start();
                    break;
            }
        }

    }
}