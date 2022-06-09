using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PozoristeProjekat.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezimeKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBGKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojRezervacija = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    PredstavaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivPredstave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zanr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojIzvodjenja = table.Column<int>(type: "int", nullable: false),
                    DatumPremijere = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.PredstavaID);
                });

            migrationBuilder.CreateTable(
                name: "Urednik",
                columns: table => new
                {
                    UrednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezimeUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBGUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoImeUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urednik", x => x.UrednikID);
                });

            migrationBuilder.CreateTable(
                name: "Pozoriste",
                columns: table => new
                {
                    PozoristeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivPozorista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozoriste", x => x.PozoristeID);
                    table.ForeignKey(
                        name: "FK_Pozoriste_Urednik_UrednikID",
                        column: x => x.UrednikID,
                        principalTable: "Urednik",
                        principalColumn: "UrednikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivSale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UkupanBrojMesta = table.Column<int>(type: "int", nullable: false),
                    PozoristeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaID);
                    table.ForeignKey(
                        name: "FK_Sala_Pozoriste_PozoristeID",
                        column: x => x.PozoristeID,
                        principalTable: "Pozoriste",
                        principalColumn: "PozoristeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Izvedba",
                columns: table => new
                {
                    IzvedbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumPrikazivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GostujucaPredstava = table.Column<bool>(type: "bit", nullable: false),
                    SalaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PredstavaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvedba", x => x.IzvedbaID);
                    table.ForeignKey(
                        name: "FK_Izvedba_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izvedba_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sediste",
                columns: table => new
                {
                    SedisteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojReda = table.Column<int>(type: "int", nullable: false),
                    Sektor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojSedista = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sediste", x => x.SedisteID);
                    table.ForeignKey(
                        name: "FK_Sediste_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumKreiranjaRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    placeno = table.Column<bool>(type: "bit", nullable: false),
                    DatumIstekaRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SedisteID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IzvedbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Izvedba_IzvedbaID",
                        column: x => x.IzvedbaID,
                        principalTable: "Izvedba",
                        principalColumn: "IzvedbaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Sediste_SedisteID",
                        column: x => x.SedisteID,
                        principalTable: "Sediste",
                        principalColumn: "SedisteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_PredstavaID",
                table: "Izvedba",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_SalaID",
                table: "Izvedba",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pozoriste_UrednikID",
                table: "Pozoriste",
                column: "UrednikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_IzvedbaID_SedisteID",
                table: "Rezervacija",
                columns: new[] { "IzvedbaID", "SedisteID" },
                unique: true,
                filter: "[IzvedbaID] IS NOT NULL AND [SedisteID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_SedisteID",
                table: "Rezervacija",
                column: "SedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_PozoristeID",
                table: "Sala",
                column: "PozoristeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sediste_SalaID",
                table: "Sediste",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Izvedba");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Sediste");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Pozoriste");

            migrationBuilder.DropTable(
                name: "Urednik");
        }
    }
}
