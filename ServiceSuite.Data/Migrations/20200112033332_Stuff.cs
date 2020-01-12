using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceSuite.Data.Migrations
{
    public partial class Stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Ticket");
        }
    }
}
