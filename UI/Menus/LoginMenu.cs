using System;
using Models;

namespace UI.Menus
{
    public class LoginMenu : IMenu
    {
        public void Start()
        {

            Console.WriteLine("Sign in or Create a new account: ");
            Console.WriteLine("[0] Sign In");
            Console.WriteLine("[1] Create New Account");
            string input = Console.ReadLine();

            switch(input)
            {
                case "0": 
                    UserLogin();
                    break;
                case "1": 
                    NewUserLogin();
                    break;
                default: 
                    Console.WriteLine("Invalid Input");
                    break;
            }


        }

        public void NewUserLogin()
        {
            bool success = false;
            bool admin = false;
            string email;
            string password;

            do
            {

                Console.Clear();
                Console.WriteLine("Enter Your Email");
                Console.WriteLine("");

                Console.Write("Email: ");
                email = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Create a Password");
                Console.WriteLine("");

                Console.Write("Password: ");
                password = Console.ReadLine();

                if(email == "valadezmykel@gmail.com" && password == "fishTaco")
                {
                    admin = true;

                }
                success = true;

            } while (!success);

            Console.WriteLine("Enter Your First Name");
            Console.Write("first name: ");
            string fName = Console.ReadLine();

            Console.WriteLine("Enter Your Last Name");
            Console.Write("last name: ");
            string lName = Console.ReadLine();

            if(admin)
            {
                try
                {
                    Manager nUser = new Manager(lName, fName, email);
                } 
                catch {
                    System.Console.WriteLine("oh no error creating a manager");
                }
            } else {
                try
                {
                    Customer nUser = new Customer(lName, fName, email);
                } catch {
                    System.Console.WriteLine("oh no unable to create customer account");
                }
            }
        }

        public void UserLogin()
        {
            bool success = false;
            string email;
            string password;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter Your Email");
                Console.WriteLine("");
                Console.Write("Email: ");
                email = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Enter Your Password");
                Console.WriteLine("");
                Console.Write("Password: ");
                password = Console.ReadLine();

                success = true;
                
            } while (!success);
            // check the db for the user
        }
    }
}