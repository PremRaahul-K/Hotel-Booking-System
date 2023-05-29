using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Range(1,1000, ErrorMessage = "HotelID should be minimum 3 chars long")]
        public int hotelID { get; set; }
        [Required(ErrorMessage = "UserName cant be empty")]
        public string? userName { get; set; }
        [Required(ErrorMessage = "Room number cant be empty")]
        public int roomNumber { get; set; }
        [Required(ErrorMessage = "Room type cant be empty")]
        public string? roomType { get; set; }
        [Required(ErrorMessage = "Check-In date cant be empty")]
        public DateTime checkInDate { get; set; }
        [Required(ErrorMessage = "Check-Out date cant be empty")]
        public DateTime checKOutDate { get; set; }
        [Required(ErrorMessage = "Price cant be empty")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Booking status cant be empty")]
        public string? bookingStatus { get; set; }
    }
}
