using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.EtablissementDb
{
    public partial class UpdatePhotoHoraire_EtabId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EtablissementId",
                table: "PhotosEtablissement",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EtablissementId",
                table: "Horaires",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 11, 52, 55, 873, DateTimeKind.Local).AddTicks(8850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 31, 10, 42, 26, 803, DateTimeKind.Local).AddTicks(1454));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EtablissementId",
                table: "PhotosEtablissement",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "EtablissementId",
                table: "Horaires",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 10, 42, 26, 803, DateTimeKind.Local).AddTicks(1454),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 31, 11, 52, 55, 873, DateTimeKind.Local).AddTicks(8850));
        }
    }
}
