using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sg_be");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "sg_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    NationalId = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PassportId = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Nationality = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "sg_be");
        }
    }
}
