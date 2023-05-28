using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Services
{
    public class BookingRepo : IRepo<int, Booking>
    {
        private readonly BookingContext _context;

        public BookingRepo(BookingContext context)
        {
            _context = context;
        }
        public Booking Add(Booking item)
        {
            try
            {
                if(item.checlOutDate<item.checkInDate)
                {
                    return null;
                }

                _context.Bookings.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (DbUpdateException ue)
            {
                return null;
            }
        }

        public Booking Delete(int key)
        {
            try
            {
                var booking = Get(key);
                _context.Remove(booking);
                _context.SaveChanges();
                return booking;
            }
            catch (DbUpdateException ue)
            {
                return null;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
        }

        public Booking Get(int key)
        {
            try
            {
                var booking = _context.Bookings.SingleOrDefault(b => b.Id == key);
                return booking;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
        }

        public ICollection<Booking> GetAll()
        {
            try
            {
                var booking = _context.Bookings.ToList();
                return booking;
            }
            catch (ArgumentNullException ane)
            {
                return null;
            }
        }

        public Booking Update(Booking item)
        {
            try
            {
                var booking = Get(item.Id);
                booking.Id = item.Id;
                booking.checkInDate = item.checkInDate;
                booking.checlOutDate = item.checlOutDate;
                booking.hotelID = item.hotelID;
                booking.userName = item.userName;
                booking.roomNumber = item.roomNumber;
                booking.bookingStatus = item.bookingStatus;
                booking.Price = item.Price;
                booking.roomType = item.roomType;
                _context.SaveChanges();
                return booking;

            }
            catch (DbUpdateException ue)
            {
                return null;
            }
        }
    }
}
