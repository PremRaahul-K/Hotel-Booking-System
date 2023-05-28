using HotelDetails.Interfaces;
using HotelDetails.Models;

namespace HotelDetails.Services
{
    public class HotelService
    {
        private readonly IRepo<int, Hotel> _hotelRepo;
        private readonly IRepo<int, Room> _roomRepo;
        private readonly IRepo<int, Amenity> _amenityRepo;

        public HotelService(IRepo<int,Hotel> hotelRepo, IRepo<int, Room> roomRepo, IRepo<int, Amenity> amenityRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
            _amenityRepo = amenityRepo;
        }
       public ICollection<Hotel> GetHotelsByLocation(string location)
        {
            try
            {
                var hotels = _hotelRepo.GetAll().Where(h => h.Location == location).ToList();
                return hotels;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
            
        }
        public ICollection<Hotel> GetHotelsByPrice(int min,int max)
        {
            try
            {
                var rooms = _roomRepo.GetAll().Where(r => r.Price >= min && r.Price <= max).ToList();
                List<Hotel> hotels = new List<Hotel>();
                SortedSet<int> hotelId = new SortedSet<int>();
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].Price >= min && rooms[i].Price <= max)
                    {
                        hotelId.Add(rooms[i].HotelId);
                    }
                }
                foreach (var item in hotelId)
                {
                    hotels.Add(_hotelRepo.Get(item));
                }
                return hotels;
            }
            catch (ArgumentNullException ane)
            {

                return null;
            }
        }
        public ICollection<Hotel> GetHotelsByAmenity(string amenity)
        {
            try
            {
                var amenities = _amenityRepo.GetAll().Where(a => a.AmenityName == amenity).ToList();
                List<Hotel> hotels = new List<Hotel>();
                SortedSet<int> hotelId = new SortedSet<int>();
                for (int i = 0; i < amenities.Count; i++)
                {
                    if (amenities[i].AmenityName.ToLower() == amenity.ToLower())
                    {
                        hotelId.Add(amenities[i].HotelId);
                    }
                }
                foreach (var item in hotelId)
                {
                    hotels.Add(_hotelRepo.Get(item));
                }
                return hotels;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
        }
    }
}
