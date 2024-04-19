using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Име"),
                    CompressiveStrengthRequired = table.Column<int>(type: "int", nullable: false, comment: "Якост на натиск на бетона")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteClasses", x => x.Id);
                },
                comment: "Клас по якост на натиск на бетона");

            migrationBuilder.CreateTable(
                name: "Deliverers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Име"),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverers", x => x.Id);
                },
                comment: "Доставчик на армировъчна стомана");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Име"),
                    DepartmentType = table.Column<int>(type: "int", nullable: false, comment: "Тип на отдела")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                },
                comment: "Отдел/Цех");

            migrationBuilder.CreateTable(
                name: "PrecastTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Име"),
                    PrecastReinforceType = table.Column<int>(type: "int", nullable: false, comment: "Начин на армиране")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecastTypes", x => x.Id);
                },
                comment: "Тип на сглобяем стоманобетонов елемент");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на обекта")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Име на обекта"),
                    ProdNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Административен номер на обекта"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата на добавяне"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Изтрит")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                },
                comment: "Обект");

            migrationBuilder.CreateTable(
                name: "ReinforceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReinforceClass = table.Column<int>(type: "int", nullable: false, comment: "Клас на стоманата"),
                    Diameter = table.Column<int>(type: "int", nullable: false, comment: "Диаметър на стоманата"),
                    SpecificMass = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Относително тегло на стоманата")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReinforceTypes", x => x.Id);
                },
                comment: "Тип армировъчна стомана");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReinforceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на заявка")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false, comment: "Заявен брой от елемента"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата на заявка"),
                    PrecastWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Тегло на заявения елемент"),
                    DeliverDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата на доставка"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false, comment: "Цех за доставка"),
                    DelivererId = table.Column<int>(type: "int", nullable: false, comment: "Доставчик")
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
                },
                comment: "Заявки за армировъчна стомана");

            migrationBuilder.CreateTable(
                name: "Precast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Име"),
                    PrecastTypeId = table.Column<int>(type: "int", nullable: false, comment: "Тип на елемента"),
                    Count = table.Column<int>(type: "int", nullable: false, comment: "Количество"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата на добавяне"),
                    ProjectId = table.Column<int>(type: "int", nullable: false, comment: "Обект"),
                    ConcreteClassId = table.Column<int>(type: "int", nullable: false, comment: "Клас на бетона"),
                    ConcreteProjectAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Проектно количество бетон"),
                    ConcreteActualAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Реално количество бетон"),
                    ReinforceProjectWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Проектно тегло на армировка"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Изтрит")
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
                },
                comment: "Сглобяем стоманобетонов елемент");

            migrationBuilder.CreateTable(
                name: "DepartmentsPrecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecastId = table.Column<int>(type: "int", nullable: false, comment: "Сглобяем стоманобетонов елемент"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false, comment: "Отдел/Цех"),
                    Count = table.Column<int>(type: "int", nullable: false, comment: "Брой наляти елементи"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата")
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
                },
                comment: "Свързваща таблица между сглобяем стоманобетонов елемент и отдел/цех");

            migrationBuilder.CreateTable(
                name: "PrecastReinforce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecastId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на елемент"),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Позиция на армировката"),
                    Count = table.Column<int>(type: "int", nullable: false, comment: "Брой"),
                    ReinforceTypeId = table.Column<int>(type: "int", nullable: false, comment: "Тип на армировката(клас стомана и диаметър)"),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Дължина на армировката"),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Тегло на армировката")
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
                },
                comment: "Армировка на елемент");

            migrationBuilder.CreateTable(
                name: "PrecastReinforceOrders",
                columns: table => new
                {
                    PrecastId = table.Column<int>(type: "int", nullable: false, comment: "Сглобяем стоманотонов елемент"),
                    ReinforceOrderId = table.Column<int>(type: "int", nullable: false, comment: "Заявка за армировъчна стомана")
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
                },
                comment: "Свързваща таблица между сглобяем стоманобетонов елемент и Заявки за армировъчна стомана");

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
                table: "Deliverers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "ioannaabadjieva@gmail.com", "TestDeliverer" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "1-st Precast" },
                    { 2, 1, "2-nd Precast" },
                    { 3, 1, "3-rd Precast" },
                    { 4, 1, "Reinforce" },
                    { 5, 1, "Mould" },
                    { 6, 1, "EmbeddedParts" },
                    { 7, 2, "Management" },
                    { 8, 2, "ProjectTechnical" }
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
                columns: new[] { "Id", "Diameter", "ReinforceClass", "SpecificMass" },
                values: new object[,]
                {
                    { 1, 6, 0, 0.222m },
                    { 2, 8, 0, 0.395m },
                    { 3, 10, 0, 0.617m },
                    { 4, 12, 0, 0.888m },
                    { 5, 14, 0, 1.21m },
                    { 6, 16, 0, 1.58m },
                    { 7, 18, 0, 2.00m }
                });

            migrationBuilder.InsertData(
                table: "ReinforceTypes",
                columns: new[] { "Id", "Diameter", "ReinforceClass", "SpecificMass" },
                values: new object[,]
                {
                    { 8, 20, 0, 2.47m },
                    { 9, 22, 0, 2.98m },
                    { 10, 25, 0, 3.85m },
                    { 11, 28, 0, 4.83m },
                    { 12, 32, 0, 6.31m },
                    { 13, 36, 0, 7.99m },
                    { 14, 40, 0, 9.87m },
                    { 15, 6, 1, 0.222m },
                    { 16, 8, 1, 0.395m },
                    { 17, 10, 1, 0.617m },
                    { 18, 12, 1, 0.888m },
                    { 19, 14, 1, 1.21m },
                    { 20, 16, 1, 1.58m },
                    { 21, 18, 1, 2.00m },
                    { 22, 20, 1, 2.47m },
                    { 23, 22, 1, 2.98m },
                    { 24, 25, 1, 3.85m },
                    { 25, 28, 1, 4.83m },
                    { 26, 32, 1, 6.31m },
                    { 27, 36, 1, 7.99m },
                    { 28, 40, 1, 9.87m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Projects_ProdNumber",
                table: "Projects",
                column: "ProdNumber",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DepartmentsPrecast");

            migrationBuilder.DropTable(
                name: "PrecastReinforce");

            migrationBuilder.DropTable(
                name: "PrecastReinforceOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
