using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{

    public class Basket
    {
        private List<Booking> bookings = new List<Booking>();

        public void AddItem(Room room)
        {
            Booking order = bookings.Where(r => r.Room.RoomId == room.RoomId)
                .FirstOrDefault();

            if (order == null)
            {
                bookings.Add(new Booking
                {
                    Room = room
                });
            }
            else
            {

            }
        }

        public void RemoveItem(Room room)
        {
            bookings.RemoveAll(l => l.Room.RoomId == room.RoomId);
        }

        public IEnumerable<Booking> book
        {
            get => bookings;
        }
    }
}
