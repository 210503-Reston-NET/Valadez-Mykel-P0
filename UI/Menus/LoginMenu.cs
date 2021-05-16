using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using DataLogic.Entities;
using DataLogic;
using BuisnessLogic;


namespace UI.Menus
{
    public class LoginMenu
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
                    this.Start();
                    break;
            }


        }

        public void NewUserLogin()
        {
            bool success = false;
            
            string email;
            string password;
            string name;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter Your Name");
                Console.WriteLine("");

                Console.Write("Name: ");
                name = Console.ReadLine();

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

                success = true;

                // add validation
            } while (!success);

            this.CheckAdminAndPass(email, password);

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
            // todo
            // check the db for the user

            this.CheckAdminAndPass(email, password);
            
        }

        public void CheckAdminAndPass(string email, string password)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            
            string connectionString = configuration.GetConnectionString("StoreDB");

            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            var context = new StoreDBContext(options);

            bool admin = false;
            if(email == "dirtEmpire@gmail.com" && password == "fishTaco")
            {
                admin = true;

            }

            if(admin)
            {
                try
                {
                    // Manager nUser = new Manager(lName, fName, email);
                    new ManagerMainMenu().Start(new BLogic(new storeDB(context));
                } 
                catch {
                    System.Console.WriteLine("oh no error creating a manager");
                }
            } else {
                try
                {
                    // Customer nUser = new Customer(lName, fName, email);
                    new CustMainMenu().Start(new BLogic(new storeDB(context));
                } catch {
                    System.Console.WriteLine("oh no unable to create customer account");
                }
            }
        }
    }
}