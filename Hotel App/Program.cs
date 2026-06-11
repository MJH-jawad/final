using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hotel_App
{
    public class Program
    {
        static List<User> users = new List<User>();                 //S.A
        static List<Room> rooms = new List<Room>();                 //Jawad
        static List<Booking> bookings = new List<Booking>();        //Jawad
        static string loggedInUser = "";


        public static void Main(string[] args)
        {
            users.Add(new User("admin", "1234", "Admin"));  //S.A
            users.Add(new User("customer", "1234", "Customer"));  //S.A

            rooms.Add(new Room(101, "Normal", 100));        //Jawad
            rooms.Add(new Room(102, "Premium", 180));       //Jawad
            rooms.Add(new Room(103, "Suite", 250));         //Jawad

            do 
            {                   //S.A
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
                             //S.A
        public static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    loggedInUser = username;
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
                         
                         //S.A
        public static void Register()
        {
            Console.Write("New Username: ");
            string userName = Console.ReadLine();

            Console.Write("New Password: ");
            string password = Console.ReadLine();

            users.Add(new User(userName, password, "Customer"));

            Console.WriteLine("Registration Successful");
        }//end of Regisrer 

                                //S.A
        public static void AdminMenu()
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
                        foreach (Room room in rooms)    //start Jawad
                        {
                            room.DisplayRoom();            
                        }
                        break;                          //end Jawad

                    case "2":
                        Console.Write("Room No: ");                              //start Jawad
                        int no = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Type: ");
                        string type = Console.ReadLine();

                        Console.Write("Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        rooms.Add(new Room(no, type, price));
                        Console.WriteLine("Room Added");                         //end Jawad
                        break;

                    case "3":
                        Console.Write("Room No: ");                             //start Jawad
                        int removeNo = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < rooms.Count; i++)
                        {
                            if (rooms[i].RoomNo == removeNo)
                            {
                                rooms.RemoveAt(i);
                                Console.WriteLine("Room Removed");
                                break;
                            }
                        }                                                        //end Jawad
                        break;

                    case "4":
                        ViewAllBookings();                          //Jawad
                        break;
                    case "5":
                        SearchRoom();                               //Jawad
                        break;
                    case "6":
                        UpdateRoom();                               //Jawad
                        break;

                    case "99":
                        run = false;                                                //Start Jawad
                        loggedInUser = "";
                        Console.WriteLine("Logged out successfully.");              //End Jawad
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }//end of switchs
            } while (run);
        }// end of admin

        public static void SearchRoom()                                 //Start Jawad
        {
            Console.Write("Enter Room Number to Search: ");
            int roomNo = Convert.ToInt32(Console.ReadLine());

            foreach (Room room in rooms)
            {
                if (room.RoomNo == roomNo)
                {
                    Console.WriteLine("Room Found!");
                    Console.WriteLine("******************");
                    Console.WriteLine("Room No = " + room.RoomNo);
                    Console.WriteLine("Room Type = " + room.RoomType);
                    Console.WriteLine("Price = $" + room.Price);
                    Console.WriteLine("Availability = " + (room.IsAvailable ? "Available" : "Booked / Not Available"));
                    return;
                }
            }

            Console.WriteLine("Room not found.");
        }//end of searchRoom

        public static void UpdateRoom()
        {
            Console.Write("Enter Room Number to Update: ");
            int roomNo = Convert.ToInt32(Console.ReadLine());

            foreach (Room room in rooms)
            {
                if (room.RoomNo == roomNo)
                {
                    Console.Write("New Room Type: ");
                    room.RoomType = Console.ReadLine();

                    Console.Write("New Price: ");
                    room.Price = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Room Updated Successfully.");
                    return;
                }
            }

            Console.WriteLine("Room not found.");
        }//end of update rooms //End Jawad

                                 // S.A
        public static void CustomerMenu()
        {
            bool run = true;

            do
            {
                Console.WriteLine("\n************ CUSTOMER MENU ******************");
                Console.WriteLine("***********************************************");
                Console.WriteLine("1.View Rooms");
                Console.WriteLine("2.Book Room");
                Console.WriteLine("3.View My Booking");                                 //Jawad
                Console.WriteLine("4.Logout");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        foreach (Room room in rooms)            //Start Jawad
                        {
                            room.DisplayRoom();
                        }                                       
                        break;

                    case "2":
                        MakeBooking();
                        break;

                    case "3":
                        ViewMyBookings();
                        break;

                    case "4":
                        run = false;
                        loggedInUser = "";
                        Console.WriteLine("Logged out successfully.");
                        break;

                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }
            } while (run);
        }// end of CustomerMenu
        public static void MakeBooking()
        {
            int availableCount = 0;

            Console.WriteLine("\nAvailable Rooms:");
            Console.WriteLine("****************");

            foreach (Room room in rooms)
            {
                if (room.IsAvailable == true)
                {
                    room.DisplayRoom();
                    availableCount++;
                }
            }

            Console.WriteLine("Total Available Rooms: " + availableCount);

            if (availableCount == 0)
            {
                Console.WriteLine("Sorry, there are no rooms available right now.");
                return;
            }

            Console.WriteLine("\nCHECK-IN INFORMATION");
            Console.WriteLine("Each booking starts from 7:00 AM.");
            Console.WriteLine("The booking ends at 7:00 AM on the check-out day.");
            Console.WriteLine("Example: 1 day = 7:00 AM today to 7:00 AM tomorrow.");

            Console.Write("Choose Room No: ");
            int roomNo = Convert.ToInt32(Console.ReadLine());

            foreach (Room room in rooms)
            {
                if (room.RoomNo == roomNo && room.IsAvailable == true)
                {
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Phone No: ");
                    string phoneNo = Console.ReadLine();

                    Console.WriteLine("Enter your check-in date using dd/mm/yyyy");
                    Console.WriteLine("Example: 15/06/2026");
                    Console.Write("Check-in Date: ");

                    DateTime checkInDate;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkInDate))
                    {
                        Console.WriteLine("Invalid date. Please use dd/mm/yyyy.");
                        Console.WriteLine("Example: 15/06/2026");
                        Console.Write("Check-in Date: ");
                    }

                    Console.Write("How many days do you want to book?: ");
                    int numberOfDays = Convert.ToInt32(Console.ReadLine());

                    DateTime checkOutDate = checkInDate.AddDays(numberOfDays);
                    double totalPrice = room.Price * numberOfDays;

                    Booking newBooking = new Booking(loggedInUser, firstName, lastName, phoneNo, checkInDate, checkOutDate, numberOfDays, room.RoomNo, room.RoomType, totalPrice);
                    bookings.Add(newBooking);

                    room.IsAvailable = false;

                    Console.WriteLine("Booking Successful");
                    Console.WriteLine("Here is your booking:");
                    newBooking.DisplayBooking();
                    return;
                }
            }

            Console.WriteLine("Room not available");
        }//end of MakeBooking


        public static void ViewAllBookings()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("No customer bookings found.");
                return;
            }

            foreach (Booking booking in bookings)
            {
                booking.DisplayBooking();
            }
        }//end of ViewAllBookings

        public static void ViewMyBookings()
        {
            bool found = false;

            foreach (Booking booking in bookings)
            {
                if (booking.UserName == loggedInUser)
                {
                    booking.DisplayBooking();
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No booking found.");
            }                                                                           //End Jawad
        }//end of ViewMyBookings
    }//end of program class
}
