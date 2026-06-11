using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_App
{
    //Start Jawad
    public class Booking
    {
        public string UserName;
        public string FirstName;
        public string LastName;
        public string PhoneNo;
        public DateTime CheckInDate;
        public DateTime CheckOutDate;
        public int NumberOfDays;
        public int RoomNo;
        public string RoomType;
        public double TotalPrice;

        public Booking(string userName, string firstName, string lastName, string phoneNo, DateTime checkInDate, DateTime checkOutDate, int numberOfDays, int roomNo, string roomType, double totalPrice)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberOfDays = numberOfDays;
            RoomNo = roomNo;
            RoomType = roomType;
            TotalPrice = totalPrice;
        }

        public void DisplayBooking()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Username       : " + UserName);
            Console.WriteLine("Customer Name  : " + FirstName + " " + LastName);
            Console.WriteLine("Phone No       : " + PhoneNo);
            Console.WriteLine("Check-in Date  : " + CheckInDate.ToString("dd/MM/yyyy") + " at 7:00 AM");
            Console.WriteLine("Check-out Date : " + CheckOutDate.ToString("dd/MM/yyyy") + " at 7:00 AM");
            Console.WriteLine("Number of Days : " + NumberOfDays + " day(s)");
            Console.WriteLine("Room No        : " + RoomNo);
            Console.WriteLine("Room Type      : " + RoomType);
            Console.WriteLine("Total Price    : $" + TotalPrice);
            Console.WriteLine("--------------------------------");
        }//End of DisplayBooking
    }
}//End Jawad
