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
            try
            {
                _context.Hotels.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (DbUpdateException ue)
            {
                return null;
            }
        }

        public Hotel Delete(int key)
        {
            try
            {
                var hotel = Get(key);
                _context.Remove(hotel);
                _context.SaveChanges();
                return hotel;
            }
            catch (DbUpdateException ue)
            {
                return null;
            }
            catch(ArgumentNullException ane)
            {
                return null;
            }
        }

        public Hotel Get(int key)
        {
            try
            {
                var hotel = _context.Hotels.Include(h => h.Rooms).Include(h => h.Amenities).SingleOrDefault(h => h.Id == key);
                return hotel;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
        }

        public ICollection<Hotel> GetAll()
        {
            try
            {
                var hotels = _context.Hotels.Include(h => h.Rooms).Include(h => h.Amenities).ToList();
                return hotels;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
        }

        public Hotel Update(Hotel item)
        {
            try
            {
                var hotel = Get(item.Id);
                hotel.Id = item.Id;
                hotel.HotelName = item.HotelName;
                hotel.Location = item.Location;
                hotel.Rooms = item.Rooms;
                _context.SaveChanges();
                return hotel;

            }
            catch (DbUpdateException ue)
            {
                return null;
            }
        }
    }
}
