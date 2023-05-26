using HotelDetails.Interfaces;
using HotelDetails.Models;
using HotelDetails.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelDetails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HotelsContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddScoped<IRepo<int, Hotel>, HotelRepo>();
            builder.Services.AddScoped<IRepo<int, Room>, RoomRepo>();
            builder.Services.AddScoped<IRepo<int, Amenity>, AmenityRepo>();
            builder.Services.AddScoped<HotelService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}