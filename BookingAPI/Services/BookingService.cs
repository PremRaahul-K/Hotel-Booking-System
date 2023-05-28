using BookingAPI.Interfaces;
using BookingAPI.Models;

namespace BookingAPI.Services
{
    public class BookingService
    {
        private readonly IRepo<int, Booking> _repo;

        public BookingService(IRepo<int,Booking> repo)
        {
            _repo=repo;
        }
        public List<Booking> GetBookingsByUsername(string username)
        {
            try
            {
                var bookings = _repo.GetAll().Where(b => b.userName == username).ToList();
                if (bookings.Count() > 0)
                {
                    return bookings;
                }
                return null;
            }
            catch (ArgumentNullException ane)
            {

                return null;
            }
        }

    }
}
