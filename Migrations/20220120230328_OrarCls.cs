using Microsoft.EntityFrameworkCore.Migrations;

namespace Orar.Migrations
{
    public partial class OrarCls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrarCls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZiOra = table.Column<string>(nullable: true),
                    ClasaID = table.Column<int>(nullable: false),
                    Clasa = table.Column<string>(nullable: true),
                    MaterieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrarCls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrarCls_Materie_MaterieID",
                        column: x => x.MaterieID,
                        principalTable: "Materie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrarCls_MaterieID",
                table: "OrarCls",
                column: "MaterieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrarCls");
        }
    }
}
