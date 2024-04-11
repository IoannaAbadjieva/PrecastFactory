using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Data.Migrations
{
    public partial class ProjectProdNumIndexed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProdNumber",
                table: "Projects",
                column: "ProdNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ProdNumber",
                table: "Projects");
        }
    }
}
