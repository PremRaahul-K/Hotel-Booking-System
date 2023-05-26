using HotelDetails.Interfaces;
using HotelDetails.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelDetails.Services
{
    public class HotelRepo : IRepo<int, Hotel>
    {
        private readonly HotelsContext _context;

        public HotelRepo(HotelsContext context)
        {
            _context = context;
        }
        public Hotel Add(Hotel item)
        {
            if(_context.Hotels.Contains(item))
            {
                return null;
            }
            _context.Hotels.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Hotel Delete(int key)
        {
            var hotel = Get(key);
            if(hotel == null)
            {
                return null;
            }
            _context.Remove(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public Hotel Get(int key)
        {
            var hotel = _context.Hotels.SingleOrDefault(h => h.Id == key);
            if(hotel != null)
            {
                return hotel;
            }
            return null;
        }

        public ICollection<Hotel> GetAll()
        {
            var hotels = _context.Hotels.Include(h=>h.Rooms).ToList();
            if (hotels.Count>0)
            {
                return hotels;
            }
            return null; 
        }

        public Hotel Update(Hotel item)
        {
            var hotel = Get(item.Id);
            if (hotel != null)
            {
                hotel.Id = item.Id;
                hotel.HotelName = item.HotelName;
                hotel.Location = item.Location;
                hotel.Rooms = item.Rooms;
                _context.SaveChanges();
                return hotel;
            }
            return null;
        }
    }
}
