using System;
using Models;

namespace UI.Menus
{
    public class CustMainMenu
    {
        public void Start()
        {
            Console.WriteLine("Welcome to JoeyBob's Dirt Super Supply");
            Console.WriteLine("What chew wan ?");
            Console.WriteLine("[0] Dirt");
            Console.WriteLine("[1] Rocks");
            Console.WriteLine("[2] Dirt with some Rocks in it");
            Console.WriteLine("[3] Rocks with some dirt in it");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    break;
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default: 
                    break;
            }
        }
    }
}