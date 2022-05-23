using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domen.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JediniceMere",
                columns: table => new
                {
                    SifraJM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivJM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JediniceMere", x => x.SifraJM);
                });

            migrationBuilder.CreateTable(
                name: "Restoran",
                columns: table => new
                {
                    RestoranID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivRestorana = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.RestoranID);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    ZaposleniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.ZaposleniID);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    UslugaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisUsluge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivUsluge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JedinicaMereSifraJM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.UslugaID);
                    table.ForeignKey(
                        name: "FK_Usluge_JediniceMere_JedinicaMereSifraJM",
                        column: x => x.JedinicaMereSifraJM,
                        principalTable: "JediniceMere",
                        principalColumn: "SifraJM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IzvestajOBrojuDorucaka",
                columns: table => new
                {
                    RBIzvestaja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UkupanBrojDorucaka = table.Column<int>(type: "int", nullable: false),
                    RestoranID = table.Column<int>(type: "int", nullable: false),
                    ZaposleniID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvestajOBrojuDorucaka", x => x.RBIzvestaja);
                    table.ForeignKey(
                        name: "FK_IzvestajOBrojuDorucaka_Restoran_RestoranID",
                        column: x => x.RestoranID,
                        principalTable: "Restoran",
                        principalColumn: "RestoranID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzvestajOBrojuDorucaka_Zaposleni_ZaposleniID",
                        column: x => x.ZaposleniID,
                        principalTable: "Zaposleni",
                        principalColumn: "ZaposleniID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaIzvestaja",
                columns: table => new
                {
                    RBStavke = table.Column<int>(type: "int", nullable: false),
                    IzvestajOBrojuDorucakaID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojDorucaka = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaIzvestaja", x => new { x.RBStavke, x.IzvestajOBrojuDorucakaID });
                    table.ForeignKey(
                        name: "FK_StavkaIzvestaja_IzvestajOBrojuDorucaka_IzvestajOBrojuDorucakaID",
                        column: x => x.IzvestajOBrojuDorucakaID,
                        principalTable: "IzvestajOBrojuDorucaka",
                        principalColumn: "RBIzvestaja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzvestajOBrojuDorucaka_RestoranID",
                table: "IzvestajOBrojuDorucaka",
                column: "RestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvestajOBrojuDorucaka_ZaposleniID",
                table: "IzvestajOBrojuDorucaka",
                column: "ZaposleniID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaIzvestaja_IzvestajOBrojuDorucakaID",
                table: "StavkaIzvestaja",
                column: "IzvestajOBrojuDorucakaID");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_JedinicaMereSifraJM",
                table: "Usluge",
                column: "JedinicaMereSifraJM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkaIzvestaja");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "IzvestajOBrojuDorucaka");

            migrationBuilder.DropTable(
                name: "JediniceMere");

            migrationBuilder.DropTable(
                name: "Restoran");

            migrationBuilder.DropTable(
                name: "Zaposleni");
        }
    }
}
