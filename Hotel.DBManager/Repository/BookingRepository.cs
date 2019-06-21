using Hotel.DBManager.Data;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DBManager.Repository
{
    public class BookingRepository : IBookingRepository
    {
        HotelContext db = new HotelContext();

        public BookingRepository(HotelContext db)
        {
            this.db = db;
        }

        public IEnumerable<Booking> Bookings => db.Bookings;

        public void Create(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
        }

        public void Edit(Booking booking)
        {
            db.Entry(booking).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Booking GetBookingById(int? id)
        {
            return db.Set<Booking>().Find(id);
        }

    }
}
