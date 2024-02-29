using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcreteClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompressiveStrengthRequired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliverers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecastTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrecastReinforceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecastTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReinforceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReinforceClass = table.Column<int>(type: "int", nullable: false),
                    Diameter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReinforceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsEmployees",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsEmployees", x => new { x.DepartmentId, x.EmployeetId });
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployees_AspNetUsers_EmployeetId",
                        column: x => x.EmployeetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReinforceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecastWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DelivererId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReinforceOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReinforceOrders_Deliverers_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Deliverers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReinforceOrders_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrecastTypeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ConcreteClassId = table.Column<int>(type: "int", nullable: false),
                    ConcreteProjectAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReinforceProjectWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precast_ConcreteClasses_ConcreteClassId",
                        column: x => x.ConcreteClassId,
                        principalTable: "ConcreteClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Precast_PrecastTypes_PrecastTypeId",
                        column: x => x.PrecastTypeId,
                        principalTable: "PrecastTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Precast_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsPrecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecastId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ConcreteAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsPrecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentsPrecast_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsPrecast_Precast_PrecastId",
                        column: x => x.PrecastId,
                        principalTable: "Precast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrecastReinforce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecastId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ReinforceTypeId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecastReinforce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrecastReinforce_Precast_PrecastId",
                        column: x => x.PrecastId,
                        principalTable: "Precast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrecastReinforce_ReinforceTypes_ReinforceTypeId",
                        column: x => x.ReinforceTypeId,
                        principalTable: "ReinforceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrecastReinforceOrders",
                columns: table => new
                {
                    PrecastId = table.Column<int>(type: "int", nullable: false),
                    ReinforceOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecastReinforceOrders", x => new { x.PrecastId, x.ReinforceOrderId });
                    table.ForeignKey(
                        name: "FK_PrecastReinforceOrders_Precast_PrecastId",
                        column: x => x.PrecastId,
                        principalTable: "Precast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrecastReinforceOrders_ReinforceOrders_ReinforceOrderId",
                        column: x => x.ReinforceOrderId,
                        principalTable: "ReinforceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConcreteClasses",
                columns: new[] { "Id", "CompressiveStrengthRequired", "Name" },
                values: new object[,]
                {
                    { 1, 8, "C 6/8" },
                    { 2, 10, "C 8/10" },
                    { 3, 12, "C 10/12" },
                    { 4, 15, "C 12/15" },
                    { 5, 20, "C 16/20" },
                    { 6, 25, "C 20/25" },
                    { 7, 30, "C 25/30" },
                    { 8, 35, "C 28/35" },
                    { 9, 37, "C 30/37" },
                    { 10, 40, "C 32/40" },
                    { 11, 45, "C 35/45" },
                    { 12, 55, "C 40/50" },
                    { 13, 55, "C 45/55" },
                    { 14, 60, "C 50/60" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Name" },
                values: new object[,]
                {
                    { 1, 0, "1-st Precast" },
                    { 2, 0, "2-nd Precast" },
                    { 3, 0, "3-rd Precast" },
                    { 4, 0, "Reinforce" },
                    { 5, 0, "Mould" },
                    { 6, 0, "EmbeddedParts" },
                    { 7, 1, "Management" },
                    { 8, 1, "ProjectTechnical" }
                });

            migrationBuilder.InsertData(
                table: "PrecastTypes",
                columns: new[] { "Id", "Name", "PrecastReinforceType" },
                values: new object[,]
                {
                    { 1, "Foundations", 1 },
                    { 2, "Column", 1 },
                    { 3, "Main Beam", 1 },
                    { 4, "Prestressed Main Beam", 2 },
                    { 5, "Secondary Beam", 1 },
                    { 6, "Prestressed Secondary Beam", 2 },
                    { 7, "Purlin", 1 },
                    { 8, "Prestressed Purlin", 2 },
                    { 9, "Panel", 1 },
                    { 10, "Hollow Core Slab", 3 },
                    { 11, "Production Use", 1 },
                    { 12, "Other", 1 }
                });

            migrationBuilder.InsertData(
                table: "ReinforceTypes",
                columns: new[] { "Id", "Diameter", "ReinforceClass" },
                values: new object[,]
                {
                    { 1, 6, 0 },
                    { 2, 8, 0 },
                    { 3, 10, 0 },
                    { 4, 12, 0 },
                    { 5, 14, 0 },
                    { 6, 16, 0 },
                    { 7, 18, 0 },
                    { 8, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "ReinforceTypes",
                columns: new[] { "Id", "Diameter", "ReinforceClass" },
                values: new object[,]
                {
                    { 9, 22, 0 },
                    { 10, 25, 0 },
                    { 11, 28, 0 },
                    { 12, 32, 0 },
                    { 13, 36, 0 },
                    { 14, 40, 0 },
                    { 15, 6, 1 },
                    { 16, 8, 1 },
                    { 17, 10, 1 },
                    { 18, 12, 1 },
                    { 19, 14, 1 },
                    { 20, 16, 1 },
                    { 21, 18, 1 },
                    { 22, 20, 1 },
                    { 23, 22, 1 },
                    { 24, 25, 1 },
                    { 25, 28, 1 },
                    { 26, 32, 1 },
                    { 27, 36, 1 },
                    { 28, 40, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsEmployees_EmployeetId",
                table: "DepartmentsEmployees",
                column: "EmployeetId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsPrecast_DepartmentId",
                table: "DepartmentsPrecast",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsPrecast_PrecastId",
                table: "DepartmentsPrecast",
                column: "PrecastId");

            migrationBuilder.CreateIndex(
                name: "IX_Precast_ConcreteClassId",
                table: "Precast",
                column: "ConcreteClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Precast_PrecastTypeId",
                table: "Precast",
                column: "PrecastTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Precast_ProjectId",
                table: "Precast",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecastReinforce_PrecastId",
                table: "PrecastReinforce",
                column: "PrecastId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecastReinforce_ReinforceTypeId",
                table: "PrecastReinforce",
                column: "ReinforceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecastReinforceOrders_ReinforceOrderId",
                table: "PrecastReinforceOrders",
                column: "ReinforceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReinforceOrders_DelivererId",
                table: "ReinforceOrders",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_ReinforceOrders_DepartmentId",
                table: "ReinforceOrders",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsEmployees");

            migrationBuilder.DropTable(
                name: "DepartmentsPrecast");

            migrationBuilder.DropTable(
                name: "PrecastReinforce");

            migrationBuilder.DropTable(
                name: "PrecastReinforceOrders");

            migrationBuilder.DropTable(
                name: "ReinforceTypes");

            migrationBuilder.DropTable(
                name: "Precast");

            migrationBuilder.DropTable(
                name: "ReinforceOrders");

            migrationBuilder.DropTable(
                name: "ConcreteClasses");

            migrationBuilder.DropTable(
                name: "PrecastTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Deliverers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
