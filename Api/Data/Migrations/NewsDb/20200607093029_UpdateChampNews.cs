using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.NewsDb
{
    public partial class UpdateChampNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estValide",
                table: "News");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "News",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 7, 11, 30, 28, 847, DateTimeKind.Local).AddTicks(1692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 16, 11, 11, 46, 520, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titre",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estAffichePremier",
                table: "News",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Titre",
                table: "News");

            migrationBuilder.DropColumn(
                name: "estAffichePremier",
                table: "News");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 16, 11, 11, 46, 520, DateTimeKind.Local).AddTicks(6796),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 7, 11, 30, 28, 847, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.AddColumn<bool>(
                name: "estValide",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
