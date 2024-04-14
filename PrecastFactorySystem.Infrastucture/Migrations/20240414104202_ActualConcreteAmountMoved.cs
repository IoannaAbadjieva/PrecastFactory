using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Data.Migrations
{
    public partial class ActualConcreteAmountMoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcreteAmount",
                table: "DepartmentsPrecast");

            migrationBuilder.AddColumn<decimal>(
                name: "ConcreteActualAmount",
                table: "Precast",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcreteActualAmount",
                table: "Precast");

            migrationBuilder.AddColumn<decimal>(
                name: "ConcreteAmount",
                table: "DepartmentsPrecast",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
