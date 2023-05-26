using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelDetails.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hotels");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rooms");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Hotels",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
