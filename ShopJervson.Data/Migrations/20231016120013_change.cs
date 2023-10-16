using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopJervson.Data.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimension");

            migrationBuilder.RenameColumn(
                name: "MaxSpeedInVaccum",
                table: "spaceships",
                newName: "MaxSpeedInVacuum");

            migrationBuilder.RenameColumn(
                name: "MaintananceCount",
                table: "spaceships",
                newName: "MaintenanceCount");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastMaintenance",
                table: "spaceships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMaintenance",
                table: "spaceships");

            migrationBuilder.RenameColumn(
                name: "MaxSpeedInVacuum",
                table: "spaceships",
                newName: "MaxSpeedInVaccum");

            migrationBuilder.RenameColumn(
                name: "MaintenanceCount",
                table: "spaceships",
                newName: "MaintananceCount");

            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    DimensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    SpaceshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.DimensionId);
                    table.ForeignKey(
                        name: "FK_Dimension_spaceships_SpaceshipId",
                        column: x => x.SpaceshipId,
                        principalTable: "spaceships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimension_SpaceshipId",
                table: "Dimension",
                column: "SpaceshipId");
        }
    }
}
