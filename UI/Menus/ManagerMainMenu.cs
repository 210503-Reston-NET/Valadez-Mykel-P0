using Models;
using System; 

namespace UI.Menus
{
    public class ManagerMainMenu : IMenu
    {
        public void Start()
        {
            Console.WriteLine("[0] Find a Customer");
            Console.WriteLine("[1] Find an Order");
            Console.WriteLine("[2] Manage a Store Location");
            
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
                    ManageStore();
                    break;
                default:
                    this.Start();
                    break;
            }
        }

        public void CustomerFinder()
        {
            System.Console.WriteLine("finding customer later");
        }

        public void OrderFinder()
        {

        }

        public void ManageStore()
        {

        }

    }
}