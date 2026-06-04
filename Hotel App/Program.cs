using System;
using System.Collections.Generic;

namespace Hotel_App
{
    public class Program
    {
        static List<User> users = new List<User>();
        
        private static string firstName;

        static void Main(string[] args)
        {
            users.Add(new User("admin", "1234", "Admin"));
            users.Add(new User("customer", "1234", "Customer"));
            
            

            do 
            {
                Console.WriteLine("\n********** JS HOTEL *************");
                Console.WriteLine("***********************************");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("99. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;

                    case "2":
                        Register();
                        break;

                    case "99":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("You choose wrong option");
                        break;
                }//end of switch
            }while (true);
        }//end of main

        static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {//1111111111111111111111111111
                if (user.UserName == username && user.Password == password)
                {
                    Console.WriteLine("you've Login Success!");

                    switch (user.Role)
                    {
                        case "Admin":
                            AdminMenu();
                            break;

                        case "Customer":
                            CustomerMenu();
                            break;
                    }
                    return;
                }
            }//end of loop

            Console.WriteLine("Wrong username/password");
        }//end of login

        static void Register()
        {
            Console.Write("New Username: ");
            string userName = Console.ReadLine();

            Console.Write("New Password: ");
            string password = Console.ReadLine();

            users.Add(new User(userName, password, "Customer"));

            Console.WriteLine("Registration Successful");
        }//end of Regisrer 

        static void AdminMenu()
        {
            bool run = true;

            do
            {
                Console.WriteLine("\n************ ADMIN MENU **************");
                Console.WriteLine("****************************************");
                Console.WriteLine("1.View Rooms");
                Console.WriteLine("2.Add Room");
                Console.WriteLine("3.Remove Room");
                Console.WriteLine("4.View Bookings");
                Console.WriteLine("5.SearchRoom");
                Console.WriteLine("6.UpdateRoom");
                Console.WriteLine("99.Logout");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("you want to View Rooms");
                        break;

                    case "2":
                        Console.Write("You want to add rooms");
                        break;

                    case "3":
                        Console.Write("you want to Remove Room");
                        break;

                    case "4":
                        Console.WriteLine("you want to View Bookings");
                        break;
                    case "5":
                        Console.WriteLine("you want to SearchRoom");
                        break;
                    case "6":
                        Console.WriteLine("you want to UpdateRoom");
                        break;

                    case "99":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }//end of switchs
            } while (run);
        }// end of admin

        static void CustomerMenu()
        {
            bool run = true;

            do
            {
                Console.WriteLine("\n************ CUSTOMER MENU ******************");
                Console.WriteLine("***********************************************");
                Console.WriteLine("1.View Rooms");
                Console.WriteLine("2.Book Room");
                Console.WriteLine("99.Logout");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("View Rooms");
                        break;

                    case "2":
                        Console.WriteLine("Book Room");
                        break;

                    case "99":
                        run = false;
                        break;
                }
            } while (run);
        }
    }//end of program class
}
