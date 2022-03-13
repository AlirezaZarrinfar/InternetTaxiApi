using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetTaxiAPI.Domain.Migrations
{
    public partial class Commit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Trips",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trips",
                table: "Passengers");
        }
    }
}
