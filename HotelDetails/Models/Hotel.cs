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
        [Range(1, 10000, ErrorMessage = "Inavlid price range. Price has to be between 1 and 10000")]
        public float Price { get; set; }
        public float Rating { get; set; }
        List<string>? Amenities { get; set; }
    }
}
