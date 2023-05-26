using System.ComponentModel.DataAnnotations;

namespace HotelDetails.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Hotel name should be minimum 3 chars long")]
        public string? HotelName { get; set; }
        [Required(ErrorMessage = "Location cant be empty")]
        public string? Location { get; set; }
        [Required(ErrorMessage = "Price cannot be empty")]
        [Range(1, 5, ErrorMessage = "Inavlid price range. Price has to be between 1 and 5")]
        public float Rating { get; set; }
        public ICollection<Amenity>? Amenities { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
