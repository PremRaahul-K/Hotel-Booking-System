using HotelDetails.Interfaces;
using HotelDetails.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace HotelDetails.Services
{
    public class RoomRepo : IRepo<int, Room>
    {
        private readonly HotelsContext _context;

        public RoomRepo(HotelsContext context)
        {
            _context = context;
        }
        public Room Add(Room item)
        {
            try
            {
                _context.Rooms.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (DbUpdateException ue) 
            {
                Debug.WriteLine(ue.Message);
                return null;
            }
            
        }

        public Room Delete(int key)
        {
            var room = Get(key);
            if (room == null)
            {
                return null;
            }
            _context.Remove(room);
            _context.SaveChanges();
            return room;
        }

        public Room Get(int key)
        {
            var room = _context.Rooms.SingleOrDefault(h => h.Id == key);
            if (room != null)
            {
                return room;
            }
            return null;
        }

        public ICollection<Room> GetAll()
        {
            var rooms = _context.Rooms.ToList();
            if (rooms.Count > 0)
            {
                return rooms;
            }
            return null;
        }

        public Room Update(Room item)
        {
            var room = Get(item.Id);
            if (room != null)
            {
                room.Id = item.Id;
                room.RoomNumber = item.RoomNumber;
                room.AvailabilityStatus = item.AvailabilityStatus;
                room.Price = item.Price;
                room.HotelId = item.HotelId;
                room.RoomType = item.RoomType;
                _context.SaveChanges();
                return room;
            }
            return null;
        }
    }
}
