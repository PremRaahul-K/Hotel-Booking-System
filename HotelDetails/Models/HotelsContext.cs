using Microsoft.EntityFrameworkCore;

namespace HotelDetails.Models
{
    public class HotelsContext:DbContext
    {
        public HotelsContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}
