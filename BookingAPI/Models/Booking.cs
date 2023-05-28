using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int hotelID { get; set; }
        public string userName { get; set; }
        public int roomNumber { get; set; }
        public string roomType { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checlOutDate { get; set; }
        public float Price { get; set; }
        public string bookingStatus { get; set; }
    }
}
