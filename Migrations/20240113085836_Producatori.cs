using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Alimentar.Migrations
{
    public partial class Producatori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producator",
                table: "Produs");

            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Produs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducatorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_ProducatorID",
                table: "Produs",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_Produs_ProducatorID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Produs");

            migrationBuilder.AddColumn<string>(
                name: "Producator",
                table: "Produs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
