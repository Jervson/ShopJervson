using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopJervson.Data.Migrations
{
    public partial class Dtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassangerCount",
                table: "spaceships",
                newName: "PassengerCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassengerCount",
                table: "spaceships",
                newName: "PassangerCount");
        }
    }
}
