using System;
using Models;
using DataLogic;
using BuisnessLogic;

namespace UI.Menus
{
    public class CustMainMenu
    {
        public void Start(BLogic BL)
        {
            Console.WriteLine("Welcome to JoeyBob's Dirt Super Supply");
            Console.WriteLine("What chew wan ?");
            Console.WriteLine();
            Console.WriteLine("[0] Order Online");
            Console.WriteLine("[1] Find a Store");
            Console.WriteLine("[2] Check on yer Orders");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    OrderOnline(BL);
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

        public void OrderOnline(BLogic BL)
        {
            Console.WriteLine("Welcome to JoeyBob's Dirt Super Supply");
            Console.WriteLine("What chew wan ?");
            Console.WriteLine();
            Console.WriteLine("[0] Dirt");
            Console.WriteLine("[1] Rocks");
            Console.WriteLine("[2] Dirt with some Rocks in it");
            Console.WriteLine("[3] Rocks with some dirt in it");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Purchase(BL, 1);

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

        public void Purchase(BLogic BL, int productId)
        {
            int orderAmount;
            int available = BL.CheckItemAmount1(productId);
            double price = BL.GetProductPrice(productId);

            while(true){
                Console.Clear();
                Console.WriteLine(available+" available");
                Console.WriteLine("How Much You Wan?");
                try{
                    orderAmount = Int32.Parse(Console.ReadLine());
                    if(orderAmount > available) throw new Exception();
                    break;
                } catch {
                    Console.WriteLine("Invalid Input");
                }

            }

            Console.WriteLine("That'll be "+(price*orderAmount));
            Console.WriteLine("Would you like to Purchase?");
            Console.WriteLine("[0] Yes");
            Console.WriteLine("[1] No");

            while(true){
                switch (Console.ReadLine())
                {
                    case "0":
                        try{
                            BL.MakePurchase(productId, orderAmount);
                            Console.WriteLine("Your Order is Complete");
                        } catch{

                        }
                }

            }

        }

        public void Nearestlocation()
        {

        }
    }
}