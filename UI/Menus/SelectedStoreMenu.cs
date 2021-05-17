using System;
using BuisnessLogic;

namespace UI.Menus
{
    public class SelectedStoreMenu
    {
        public void Start(BLogic BL)
        {
            Console.WriteLine("[0] View Inventory");
            Console.WriteLine("[1] Add Inventory");
            Console.WriteLine("[2] View Transcations");
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    BL.ViewInventory();
                    break;
                case "1": 
                    BL.AddInventory();
                    break;
                case "2": 
                    
                    break;
                default:
                    Console.WriteLine("invalid input");
                    this.Start(BL);
                    break;
            }
        }

    }
}