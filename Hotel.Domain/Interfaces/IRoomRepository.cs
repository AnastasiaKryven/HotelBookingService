using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IRoomRepository
    {        
        IEnumerable<Room> Rooms { get; }

        Room GetRoomById (int? id);

        void Create(Room room);

        void SaveRoom(Room room);

        void Delete(int? id);
    }
}
