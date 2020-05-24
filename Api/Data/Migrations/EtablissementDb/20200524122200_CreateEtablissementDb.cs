using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.EtablissementDb
{
    public partial class CreateEtablissementDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etablissements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    NumeroTva = table.Column<string>(nullable: false),
                    AdresseEmailPro = table.Column<string>(maxLength: 255, nullable: false),
                    ZoneTexteLibre = table.Column<string>(maxLength: 2000, nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    CodePostal = table.Column<string>(maxLength: 20, nullable: false),
                    Ville = table.Column<string>(maxLength: 100, nullable: false),
                    Pays = table.Column<string>(nullable: false),
                    Rue = table.Column<string>(maxLength: 100, nullable: false),
                    NumeroBoite = table.Column<string>(maxLength: 20, nullable: false),
                    NumeroTelephone = table.Column<string>(maxLength: 25, nullable: true),
                    AdresseEmailEtablissement = table.Column<string>(maxLength: 255, nullable: true),
                    AdresseSiteWeb = table.Column<string>(nullable: true),
                    AdresseInstagram = table.Column<string>(nullable: true),
                    AdresseFacebook = table.Column<string>(nullable: true),
                    AdresseLinkedin = table.Column<string>(nullable: true),
                    PublieParUserId = table.Column<Guid>(nullable: false),
                    DatePublication = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 24, 14, 22, 0, 129, DateTimeKind.Local).AddTicks(6853)),
                    estValide = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Jour = table.Column<string>(nullable: true),
                    HeureOuverture = table.Column<TimeSpan>(nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(nullable: false),
                    EtablissementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horaires_Etablissements_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "Etablissements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotosEtablissement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomFichier = table.Column<string>(nullable: true),
                    EtablissementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosEtablissement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosEtablissement_Etablissements_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "Etablissements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horaires_EtablissementId",
                table: "Horaires",
                column: "EtablissementId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosEtablissement_EtablissementId",
                table: "PhotosEtablissement",
                column: "EtablissementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horaires");

            migrationBuilder.DropTable(
                name: "PhotosEtablissement");

            migrationBuilder.DropTable(
                name: "Etablissements");
        }
    }
}
