using System;

namespace Models
{
    public class Store
    {
        string locationName;
        int productQuantity1;
        int productQuantity2; 

        public void ProductsInStock()
        {
            Console.WriteLine("Here is the amount of product 1: "+this.productQuantity1);
            Console.WriteLine("Here is the amount of product 1: "+this.productQuantity2);
        }

    }
}