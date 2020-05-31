using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.EtablissementDb
{
    public partial class _31052020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 10, 42, 26, 803, DateTimeKind.Local).AddTicks(1454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 30, 18, 23, 24, 785, DateTimeKind.Local).AddTicks(9651));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 18, 23, 24, 785, DateTimeKind.Local).AddTicks(9651),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 31, 10, 42, 26, 803, DateTimeKind.Local).AddTicks(1454));
        }
    }
}
