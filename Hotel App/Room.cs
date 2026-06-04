using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_App
{
    public class Room
    {
        public int RoomNo;
        public string RoomType;
        public double Price;
        public bool IsAvailable;

        public Room(int roomNo, string roomType, double price)
        {
            RoomNo = roomNo;
            RoomType = roomType;
            Price = price;
            IsAvailable = true;
        }

        public void DisplayRoom()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Room No      : " + RoomNo);
            Console.WriteLine("Room Type    : " + RoomType);
            Console.WriteLine("Price/Night  : $" + Price);
            Console.WriteLine("Available    : " + (IsAvailable ? "Yes" : "No"));
        }
    }
}
