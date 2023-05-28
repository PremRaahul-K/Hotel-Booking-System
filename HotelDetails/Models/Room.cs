namespace HotelDetails.Models
{
    public class Room
    { 
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string AvailabilityStatus { get; set; }
        public string? RoomType { get; set; }
        public float Price { get; set; }
        public int HotelId { get; set; }
    }
}
