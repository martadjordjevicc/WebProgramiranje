using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LetnjiBar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetnjiBar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lezaljka",
                columns: table => new
                {
                    BrojLezaljke = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BarIDBara = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezaljka", x => x.BrojLezaljke);
                    table.ForeignKey(
                        name: "FK_Lezaljka_LetnjiBar_BarIDBara",
                        column: x => x.BarIDBara,
                        principalTable: "LetnjiBar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hrana = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BarIDBara = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Porudzbina_LetnjiBar_BarIDBara",
                        column: x => x.BarIDBara,
                        principalTable: "LetnjiBar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lezaljka_BarIDBara",
                table: "Lezaljka",
                column: "BarIDBara");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_BarIDBara",
                table: "Porudzbina",
                column: "BarIDBara");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezaljka");

            migrationBuilder.DropTable(
                name: "Porudzbina");

            migrationBuilder.DropTable(
                name: "LetnjiBar");
        }
    }
}
