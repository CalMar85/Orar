using Microsoft.EntityFrameworkCore.Migrations;

namespace Orar.Migrations
{
    public partial class Materie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clasa",
                table: "OrarCls");

            migrationBuilder.CreateIndex(
                name: "IX_OrarCls_ClasaID",
                table: "OrarCls",
                column: "ClasaID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrarCls_Clasa_ClasaID",
                table: "OrarCls",
                column: "ClasaID",
                principalTable: "Clasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrarCls_Clasa_ClasaID",
                table: "OrarCls");

            migrationBuilder.DropIndex(
                name: "IX_OrarCls_ClasaID",
                table: "OrarCls");

            migrationBuilder.AddColumn<string>(
                name: "Clasa",
                table: "OrarCls",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
