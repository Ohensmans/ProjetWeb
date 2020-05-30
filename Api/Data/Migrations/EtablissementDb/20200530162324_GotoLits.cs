using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.EtablissementDb
{
    public partial class GotoLits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 18, 23, 24, 785, DateTimeKind.Local).AddTicks(9651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 24, 14, 22, 0, 129, DateTimeKind.Local).AddTicks(6853));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Etablissements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 14, 22, 0, 129, DateTimeKind.Local).AddTicks(6853),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 30, 18, 23, 24, 785, DateTimeKind.Local).AddTicks(9651));
        }
    }
}
