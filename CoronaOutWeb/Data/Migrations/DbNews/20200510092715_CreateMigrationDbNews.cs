using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaOutWeb.Data.Migrations.DbNews
{
    public partial class CreateMigrationDbNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    estValide = table.Column<bool>(nullable: false),
                    PublieParUserId = table.Column<string>(nullable: false),
                    DatePublication = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 10, 11, 27, 15, 451, DateTimeKind.Local).AddTicks(6165))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
