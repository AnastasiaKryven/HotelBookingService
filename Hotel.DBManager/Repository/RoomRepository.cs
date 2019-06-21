using Hotel.DBManager.Data;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DBManager.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private HotelContext db = new HotelContext();

        public RoomRepository(HotelContext db)
        {
            this.db = db;
        }

        public IEnumerable<Room> Rooms => db.Rooms;
       
        public Room GetRoomById(int? id)
        {
            return db.Set<Room>().Find(id);
        }

        public void Create(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public void SaveRoom(Room room)
        {
            if (room.RoomId == 0)
            {
                Create(room);
            }
            else

            {
                var dbEntry = db.Rooms.Find(room.RoomId);
                if (dbEntry != null)
                {
                    dbEntry.CountOfPeople = room.CountOfPeople;
                    dbEntry.ImageData = room.ImageData;
                    dbEntry.ImageMimeType = room.ImageMimeType;
                    dbEntry.Price = room.Price;
                    dbEntry.RoomClass = room.RoomClass;
                    dbEntry.RoomState = room.RoomState;
                }
            }
            db.SaveChanges();

        }
        public void Delete(int? id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }

        //public void Edit(int? id)
        //{
        //    throw new NotImplementedException();
        //}
       
    }
}
