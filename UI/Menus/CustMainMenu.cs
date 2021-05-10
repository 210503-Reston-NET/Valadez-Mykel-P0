using System;
using Models;

namespace UI.Menus
{
    public class CustMainMenu : IMenu
    {
        public void Start(Customer user)
        {
            Console.WriteLine("This is the store");
            Console.WriteLine("Select an option");
            Console.WriteLine("[0] First option");
            Console.WriteLine("[1] Second option");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    break;
                case "1":
                    break;
                default: 
                    break;
            }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}