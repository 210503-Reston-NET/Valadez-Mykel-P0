using System;
using BuisnessLogic;
using UI;

namespace UI.Menus
{
    public class StoreMenu
    {
        public void Start()
        {
            Console.WriteLine("[0] Search for Location");
            Console.WriteLine("[1] Add a Location");
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    LocationSearch();
                    break;
                case "1": 
                    AddLocation();
                    break;
                default:
                    Console.WriteLine("invalid input");
                    this.Start();
                    break;
            }
        }

        public void LocationSearch()
        {
            Console.WriteLine("Enter the Name of the Location: ");
            string input = Console.ReadLine();
            // new LocationLogic().LocationHolderFunc(input);

        }

        public void AddLocation()
        {
            Console.WriteLine("Enter the Name of the New Location: ");
            string locationName = Console.ReadLine();
            // add it to the db then open it in new location menu
        }
    }
}