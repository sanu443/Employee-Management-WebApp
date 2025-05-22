using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProiectNou1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noduri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nume = table.Column<string>(type: "text", nullable: false),
                    Tip = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noduri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posturi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumePost = table.Column<string>(type: "text", nullable: false),
                    DescrierePost = table.Column<string>(type: "text", nullable: false),
                    FisaPostului = table.Column<string>(type: "text", nullable: false),
                    NrAngajatiNecesari = table.Column<int>(type: "integer", nullable: false),
                    NrPosturiOcupate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posturi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organigrame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeOrganigrama = table.Column<string>(type: "text", nullable: false),
                    MermaidCode = table.Column<string>(type: "text", nullable: false),
                    NodRootId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organigrame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organigrame_Noduri_NodRootId",
                        column: x => x.NodRootId,
                        principalTable: "Noduri",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Relatii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nod1Id = table.Column<int>(type: "integer", nullable: false),
                    Nod2Id = table.Column<int>(type: "integer", nullable: false),
                    NumeRelatie = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatii_Noduri_Nod1Id",
                        column: x => x.Nod1Id,
                        principalTable: "Noduri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatii_Noduri_Nod2Id",
                        column: x => x.Nod2Id,
                        principalTable: "Noduri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nume = table.Column<string>(type: "text", nullable: false),
                    InitialaTata = table.Column<char>(type: "character(1)", nullable: false),
                    Prenume = table.Column<string>(type: "text", nullable: false),
                    AngajatCurent = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    AdresaDomiciliu = table.Column<string>(type: "text", nullable: false),
                    CNP = table.Column<string>(type: "text", nullable: false),
                    ScoalaAbsolvita = table.Column<string>(type: "text", nullable: false),
                    MediaConcurs = table.Column<float>(type: "real", nullable: false),
                    DataAngajare = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SalariuCurent = table.Column<float>(type: "real", nullable: false),
                    MediaSalarii2Ani = table.Column<float>(type: "real", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    DepartamentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Angajati_Posturi_PostId",
                        column: x => x.PostId,
                        principalTable: "Posturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nume = table.Column<string>(type: "text", nullable: false),
                    Descriere = table.Column<string>(type: "text", nullable: false),
                    SefId = table.Column<int>(type: "integer", nullable: true),
                    OrganigramaInternaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamente_Angajati_SefId",
                        column: x => x.SefId,
                        principalTable: "Angajati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departamente_Organigrame_OrganigramaInternaId",
                        column: x => x.OrganigramaInternaId,
                        principalTable: "Organigrame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajati_DepartamentId",
                table: "Angajati",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Angajati_PostId",
                table: "Angajati",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamente_OrganigramaInternaId",
                table: "Departamente",
                column: "OrganigramaInternaId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamente_SefId",
                table: "Departamente",
                column: "SefId");

            migrationBuilder.CreateIndex(
                name: "IX_Organigrame_NodRootId",
                table: "Organigrame",
                column: "NodRootId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatii_Nod1Id",
                table: "Relatii",
                column: "Nod1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Relatii_Nod2Id",
                table: "Relatii",
                column: "Nod2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Angajati_Departamente_DepartamentId",
                table: "Angajati",
                column: "DepartamentId",
                principalTable: "Departamente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Angajati_Departamente_DepartamentId",
                table: "Angajati");

            migrationBuilder.DropTable(
                name: "Relatii");

            migrationBuilder.DropTable(
                name: "Departamente");

            migrationBuilder.DropTable(
                name: "Angajati");

            migrationBuilder.DropTable(
                name: "Organigrame");

            migrationBuilder.DropTable(
                name: "Posturi");

            migrationBuilder.DropTable(
                name: "Noduri");
        }
    }
}
