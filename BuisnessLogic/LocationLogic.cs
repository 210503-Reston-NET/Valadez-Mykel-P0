using System;
using System.Collections.Generic;
using Models;

namespace BuisnessLogic
{
    public class LocationLogic
    {
        public void LocationHolderFunc(string name)
        {
            // find the location and info
            System.Console.WriteLine(name);
        }
        public void ViewIneventory(Store store)
        {
            store.ProductsInStock();
        }
 
    }
}