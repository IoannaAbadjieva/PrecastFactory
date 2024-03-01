#nullable disable

namespace PrecastFactorySystem.Data.Migrations
{
	using System;

	using Microsoft.EntityFrameworkCore.Migrations;

	public partial class DateAddedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProdNumber",
                table: "Projects",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Precast",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProdNumber",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Precast");
        }
    }
}
