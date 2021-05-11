using System;
using System.Collections.Generic;
using Models;

namespace BuisnessLogic
{
    public class LocationLogic
    {
        public void ViewIneventory(Store store)
        {
            store.ProductsInStock();
        } 
    }
}