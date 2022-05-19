using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTicketMachine.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1289b8a0-3aba-4610-95a8-aee8169b6325"), "text" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("272d56b6-d75f-4c35-9e50-dbda9a64dd21"), "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
