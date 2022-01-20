using Microsoft.EntityFrameworkCore.Migrations;

namespace Orar.Migrations
{
    public partial class ClasaProfesor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterieID",
                table: "Profesor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clasa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClasa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMaterie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClasaProfesor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorID = table.Column<int>(nullable: false),
                    ClasaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasaProfesor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClasaProfesor_Clasa_ClasaID",
                        column: x => x.ClasaID,
                        principalTable: "Clasa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClasaProfesor_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_MaterieID",
                table: "Profesor",
                column: "MaterieID");

            migrationBuilder.CreateIndex(
                name: "IX_ClasaProfesor_ClasaID",
                table: "ClasaProfesor",
                column: "ClasaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClasaProfesor_ProfesorID",
                table: "ClasaProfesor",
                column: "ProfesorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Materie_MaterieID",
                table: "Profesor",
                column: "MaterieID",
                principalTable: "Materie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Materie_MaterieID",
                table: "Profesor");

            migrationBuilder.DropTable(
                name: "ClasaProfesor");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropTable(
                name: "Clasa");

            migrationBuilder.DropIndex(
                name: "IX_Profesor_MaterieID",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "MaterieID",
                table: "Profesor");
        }
    }
}
