using System;

namespace UI.Menus
{
    public class CustMainMenu : IMenu
    {
        public void Start()
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
    }
}