using System.ComponentModel.DataAnnotations;

namespace HotelDetails.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Room number cant be empty")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Availability cant be empty")]
        public string? AvailabilityStatus { get; set; }
        [Required(ErrorMessage = "Room type cant be empty")]
        public string? RoomType { get; set; }
        [Required(ErrorMessage = "Price cant be empty")]
        [Range(1,10000,ErrorMessage = "Invalid price range. Price has to be between 1 and 10000")]
        public float Price { get; set; }
        [Required(ErrorMessage = "HotelId cant be empty")]
        public int HotelId { get; set; }
    }
}
