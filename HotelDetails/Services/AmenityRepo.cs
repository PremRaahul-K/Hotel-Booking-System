using HotelDetails.Interfaces;
using HotelDetails.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace HotelDetails.Services
{
    public class AmenityRepo : IRepo<int, Amenity>
    {
        private readonly HotelsContext _context;

        public AmenityRepo(HotelsContext context)
        {
            _context = context;
        }
        public Amenity Add(Amenity item)
        {
            if (_context.Amenities.Contains(item))
            {
                return null;
            }
            _context.Amenities.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Amenity Delete(int key)
        {
            var amenity = Get(key);
            if (amenity == null)
            {
                return null;
            }
            _context.Remove(amenity);
            _context.SaveChanges();
            return amenity;
        }

        public Amenity Get(int key)
        {
            var amenity = _context.Amenities.SingleOrDefault(h => h.Id == key);
            if (amenity != null)
            {
                return amenity;
            }
            return null;
        }

        public ICollection<Amenity> GetAll()
        {
            var amenities = _context.Amenities.ToList();
            if (amenities.Count > 0)
            {
                return amenities;
            }
            return null;
        }

        public Amenity Update(Amenity item)
        {
            var amenity = Get(item.Id);
            if (amenity != null)
            {
                amenity.Id = item.Id;
                amenity.HotelId = item.HotelId;
                amenity.AmenityName = item.AmenityName;
                _context.SaveChanges();
                return amenity;
            }
            return null;
        }
    }
}
