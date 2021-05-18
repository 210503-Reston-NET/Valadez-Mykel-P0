using Models;
using System;
using BuisnessLogic;
using DataLogic; 

namespace UI.Menus
{
    public class ManagerMainMenu
    {
        public void Start(BLogic BL)
        {
            
            Console.Clear();
            Console.WriteLine("[0] Find a Customer");
            Console.WriteLine("[1] Find an Order");
            Console.WriteLine("[2] Manage a Store Location");
            Console.WriteLine("[3] View All Locations");
            
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    CustomerFinder(BL);
                    break;
                case "1":
                    OrderFinder(BL);
                    break;
                case "2":
                    new StoreMenu().Start(BL);
                    break;
                case "3":
                    BL.GetAllStores();
                    break;
                default:
                    this.Start(BL);
                    break;
            }
        }

        public void CustomerFinder(BLogic BL)
        {
            Console.Clear();
            Console.WriteLine("What Would you like to Search by?");
            Console.WriteLine("[0] Customer Id");
            Console.WriteLine("[1] Customer Name");
            Console.WriteLine("[2] Back");

            while(true){
                switch(Console.ReadLine()){
                    case "1":
                        Console.WriteLine("Enter in the Customer Name: ");
                        try{
                            BL.FindUser(Console.ReadLine());
                        }catch{
                            Console.WriteLine("unable to Find Customer");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Enter in the Customer Id: ");
                        string input = Console.ReadLine();
                        if(Int32.TryParse(input, out int id)){
                            BL.FindUser(id);
                        }else {
                            Console.WriteLine("Invalid Input");
                        }
                        break;
                    case "2":
                        Start(BL);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
            }
        }

        public void OrderFinder(BLogic BL)
        {
            Console.Clear();
            Console.WriteLine("Enter the Order Id");

            if(Int32.TryParse(Console.ReadLine(), out int id)){
                BL.CheckOrder(id);
            }else{
                Console.WriteLine("Unable to Find Order, Press any Key to Continue");

                if(Console.ReadLine() != null) Start(BL);
            }
        }

    }
}