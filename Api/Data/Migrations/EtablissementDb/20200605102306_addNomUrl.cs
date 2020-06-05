using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.EtablissementDb
{
    public partial class addNomUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 5, 12, 23, 5, 921, DateTimeKind.Local).AddTicks(437),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 31, 11, 52, 55, 873, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.AddColumn<string>(
                name: "NomUrl",
                table: "Etablissements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomUrl",
                table: "Etablissements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 11, 52, 55, 873, DateTimeKind.Local).AddTicks(8850),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 5, 12, 23, 5, 921, DateTimeKind.Local).AddTicks(437));
        }
    }
}
