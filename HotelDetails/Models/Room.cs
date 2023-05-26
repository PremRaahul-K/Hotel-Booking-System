namespace HotelDetails.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public bool AvailabilityStatus { get; set; }
        public string? RoomType { get; set; }
        public int HotelId { get; set; }
    }
}
