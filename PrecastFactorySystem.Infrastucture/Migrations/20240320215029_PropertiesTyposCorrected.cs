using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Data.Migrations
{
    public partial class PropertiesTyposCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsEmployees_AspNetUsers_EmployeetId",
                table: "DepartmentsEmployees");

            migrationBuilder.RenameColumn(
                name: "EmployeetId",
                table: "DepartmentsEmployees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentsEmployees_EmployeetId",
                table: "DepartmentsEmployees",
                newName: "IX_DepartmentsEmployees_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsEmployees_AspNetUsers_EmployeeId",
                table: "DepartmentsEmployees",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsEmployees_AspNetUsers_EmployeeId",
                table: "DepartmentsEmployees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "DepartmentsEmployees",
                newName: "EmployeetId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentsEmployees_EmployeeId",
                table: "DepartmentsEmployees",
                newName: "IX_DepartmentsEmployees_EmployeetId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsEmployees_AspNetUsers_EmployeetId",
                table: "DepartmentsEmployees",
                column: "EmployeetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
