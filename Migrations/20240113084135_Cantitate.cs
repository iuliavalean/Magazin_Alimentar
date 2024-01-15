using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Alimentar.Migrations
{
    public partial class Cantitate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cantitate",
                table: "Produs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "Produs");
        }
    }
}
