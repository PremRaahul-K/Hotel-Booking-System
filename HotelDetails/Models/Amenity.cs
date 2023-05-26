namespace HotelDetails.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string? AmenityName { get; set; }
        public int  HotelId { get; set; }
    }
}
