using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.NewsDb
{
    public partial class CreateDbNews : Migration
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
                    DatePublication = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 16, 11, 11, 46, 520, DateTimeKind.Local).AddTicks(6796))
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
