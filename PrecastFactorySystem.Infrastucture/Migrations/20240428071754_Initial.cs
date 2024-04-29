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
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата на добавяне")
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
                    ReinforceProjectWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Проектно тегло на армировка")
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrecastReinforceOrders_ReinforceOrders_ReinforceOrderId",
                        column: x => x.ReinforceOrderId,
                        principalTable: "ReinforceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Свързваща таблица между сглобяем стоманобетонов елемент и Заявки за армировъчна стомана");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("13a26afc-8c31-4777-b202-89966774aaa5"), 0, "8f8550c0-dcfb-4c74-a4de-919a998c39e7", "admin@mail.com", true, "Chief", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEArX3rhxuM4WSU0bGCHEkpLJ4OJdCQv8H8F5r3ydocQw77tT8fPqGZ/TQ49y1ZSCvA==", null, false, "20A69DED-6E70-41C4-A14B-6898C401B1CA", false, "admin" },
                    { new Guid("344ef066-7d16-480d-b1d3-6face05c7c62"), 0, "5fea0ca6-4c74-4b17-8df5-16adae1bab08", "manager@mail.com", true, "General", "Manager", false, null, "MANAGER@MAIL.COM", "MANAGER", "AQAAAAEAACcQAAAAEID5r6jIa0Ku2aGNQrr1SybyRmdu3LX92NAOi5B+NP4EI0mhh3cfj0vtn1bFBjDiRw==", null, false, "083AB38D-6731-44CC-81B4-50B829E86BB4", false, "manager" },
                    { new Guid("af7811c7-760b-42c4-b3ed-42cd794e5153"), 0, "2a20f04d-a194-4e64-8838-1af7d4d8b81d", "reinforce@mail.com", true, "Reinforce", "Manager", false, null, "REINFORCE@MAIL.COM", "REINFORCE_MANAGER", "AQAAAAEAACcQAAAAEI3qZwin+TtrCGO7vzgv2f9+BCUSGkQePMp7GF/Zn6TO8HR9YfsUVN7MoVbwxmLxjg==", null, false, "B077E983-5A5F-434A-9418-3FDEE1E59163", false, "reinforce_manager" },
                    { new Guid("ed91d639-dfe6-4d7f-9a19-bc8a1f3a1fbe"), 0, "4bbbc8d1-d671-40e2-a850-1f4f019f20b0", "production@mail.com", true, "Production", "Manager", false, null, "PRODUCTION@MAIL.COM", "PRODUCTION_MANAGER", "AQAAAAEAACcQAAAAENQSrSVa43S2U8AWGHKLonwwIs81bF7OK9g7+K6gmvOjq7SlFUnWTVSxDBx4J0eFbQ==", null, false, "382B1A56-1161-4FB2-A7AA-921483A54055", false, "production_manager" },
                    { new Guid("f8927215-501c-43ab-92da-972bf9934a93"), 0, "3cc50cfb-d39c-4371-ac30-b020bb80e85a", "user@mail.com", true, "Ordinary", "User", false, null, "USER@MAIL.COM", "USER", "AQAAAAEAACcQAAAAEJzQeKjVFitU54cgZ2DcnUHT/bS+lPtos6NZ0Wdfl/MnQIuy/jXVATYVEAP03Jp77Q==", null, false, "1D75DA64-D920-451F-AA99-D555A5AF4E75", false, "user" }
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
                table: "Deliverers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "ioannaabadjieva@gmail.com", "TestDeliverer" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Name" },
                values: new object[,]
                {
                    { 1, 0, "1-st Precast" },
                    { 2, 0, "2-nd Precast" },
                    { 3, 0, "3-rd Precast" },
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
                table: "Projects",
                columns: new[] { "Id", "AddedOn", "Name", "ProdNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 18, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(772), "Yung Solent", "24-101" },
                    { 2, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(801), "Argus", "24-102" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AddedOn", "Name", "ProdNumber" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(804), "DM", "24-103" },
                    { 4, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(806), "Delita", "24-104" }
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
                    { 7, 18, 0, 2.00m },
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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Chief Admin", new Guid("13a26afc-8c31-4777-b202-89966774aaa5") },
                    { 2, "user:fullname", "General Manager", new Guid("344ef066-7d16-480d-b1d3-6face05c7c62") },
                    { 3, "user:fullname", "Reinforce Manager", new Guid("af7811c7-760b-42c4-b3ed-42cd794e5153") },
                    { 4, "user:fullname", "Production Manager", new Guid("ed91d639-dfe6-4d7f-9a19-bc8a1f3a1fbe") },
                    { 5, "user:fullname", "Ordinary User", new Guid("f8927215-501c-43ab-92da-972bf9934a93") }
                });

            migrationBuilder.InsertData(
                table: "Precast",
                columns: new[] { "Id", "AddedOn", "ConcreteActualAmount", "ConcreteClassId", "ConcreteProjectAmount", "Count", "Name", "PrecastTypeId", "ProjectId", "ReinforceProjectWeight" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(868), 7.22m, 12, 7.32m, 10, "K тип 4", 2, 1, 1900m },
                    { 2, new DateTime(2024, 4, 14, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(873), 9.16m, 12, 9.32m, 8, "K тип 6", 2, 1, 2412m },
                    { 3, new DateTime(2024, 4, 14, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(876), 6.98m, 12, 7.11m, 6, "K тип 5", 2, 1, 1650m },
                    { 4, new DateTime(2024, 4, 14, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(907), 5.16m, 12, 5.32m, 2, "K тип 3", 2, 1, 1495m },
                    { 5, new DateTime(2024, 4, 18, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(910), 7.22m, 12, 7.22m, 6, "K тип 1", 2, 1, 1560m },
                    { 6, new DateTime(2024, 4, 18, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(913), 7.22m, 12, 7.22m, 6, "K тип 2", 2, 1, 1710m },
                    { 7, new DateTime(2024, 4, 18, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(916), 1.61m, 9, 1.61m, 24, "СЧ 1", 1, 1, 384m },
                    { 8, new DateTime(2024, 4, 18, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(918), 1.97m, 9, 1.97m, 10, "СЧ 1a", 1, 1, 400m },
                    { 9, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(921), 1.61m, 9, 1.61m, 36, "MЧ 1", 1, 2, 375m },
                    { 10, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(923), 7.90m, 12, 7.88m, 9, "K тип 1,1а,1б", 2, 2, 1291m },
                    { 11, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(926), 7.90m, 12, 7.88m, 5, "K тип 2,2а", 2, 2, 1312m },
                    { 12, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(929), 9.6m, 14, 9.54m, 4, "ГГ 1", 4, 2, 1620m },
                    { 13, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(932), 1.2m, 14, 1.24m, 4, "Ст. 1", 8, 2, 252m },
                    { 14, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(934), 1.25m, 14, 1.24m, 3, "Ст.2A,2B", 8, 2, 254m },
                    { 15, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(937), 2.24m, 9, 2.34m, 16, "Ч 1", 1, 3, 397m },
                    { 16, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(939), 1.46m, 9, 1.58m, 37, "Ч 2", 1, 3, 274m },
                    { 17, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(942), 4.04m, 14, 4.10m, 12, "ПГр.2.1", 4, 3, 1257m },
                    { 18, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(944), 4.54m, 14, 4.72m, 20, "ПГр.1.1", 4, 3, 1430m },
                    { 19, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(947), 1.67m, 12, 1.59m, 3, "ПС 2.1", 5, 3, 378m },
                    { 20, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(949), 1.65m, 12, 1.59m, 1, "ПС 2.2", 5, 3, 374m },
                    { 21, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(952), 1.65m, 12, 1.59m, 1, "ПС 2.3", 5, 3, 364m }
                });

            migrationBuilder.InsertData(
                table: "ReinforceOrders",
                columns: new[] { "Id", "Count", "DeliverDate", "DelivererId", "DepartmentId", "OrderDate", "PrecastWeight" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1408), 1, 4, new DateTime(2024, 4, 19, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1401), 362.34m },
                    { 2, 6, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1412), 1, 4, new DateTime(2024, 4, 19, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1411), 375.35m },
                    { 3, 4, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1415), 1, 1, new DateTime(2024, 4, 19, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1414), 1826.74m },
                    { 4, 4, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1419), 1, 1, new DateTime(2024, 4, 19, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1417), 1575.52m },
                    { 5, 6, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1423), 1, 2, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1421), 1282.15m },
                    { 6, 4, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1426), 1, 2, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1425), 1590.3m },
                    { 7, 4, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1429), 1, 3, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1428), 261.51m },
                    { 8, 3, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1434), 1, 3, new DateTime(2024, 4, 21, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1431), 258.45m },
                    { 9, 6, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1438), 1, 1, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1436), 1826.74m },
                    { 10, 6, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1441), 1, 4, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1440), 362.34m },
                    { 11, 4, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1444), 1, 4, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1443), 375.35m },
                    { 12, 2, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1448), 1, 2, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1446), 1575.52m },
                    { 13, 2, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1451), 1, 2, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1449), 1703.67m },
                    { 14, 3, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1454), 1, 2, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1453), 1282.15m },
                    { 15, 6, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1458), 1, 4, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1456), 286.16m },
                    { 16, 4, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1461), 1, 1, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1460), 2386.87m }
                });

            migrationBuilder.InsertData(
                table: "ReinforceOrders",
                columns: new[] { "Id", "Count", "DeliverDate", "DelivererId", "DepartmentId", "OrderDate", "PrecastWeight" },
                values: new object[,]
                {
                    { 17, 3, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1465), 1, 3, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1463), 368.88m },
                    { 18, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1468), 1, 3, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1466), 368.31m },
                    { 19, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1471), 1, 3, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1469), 360.01m },
                    { 20, 4, new DateTime(2024, 4, 29, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1475), 1, 2, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1473), 1703.67m },
                    { 21, 2, new DateTime(2024, 4, 29, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1479), 1, 3, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1477), 1295.08m },
                    { 22, 4, new DateTime(2024, 4, 30, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1484), 1, 2, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1482), 1244.27m },
                    { 23, 4, new DateTime(2024, 4, 30, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1488), 1, 2, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(1486), 1411.44m }
                });

            migrationBuilder.InsertData(
                table: "DepartmentsPrecast",
                columns: new[] { "Id", "Count", "Date", "DepartmentId", "PrecastId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3772), 1, 7 },
                    { 2, 1, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3782), 1, 8 },
                    { 3, 1, new DateTime(2024, 4, 22, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3784), 1, 1 },
                    { 4, 1, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3786), 1, 7 },
                    { 5, 1, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3788), 1, 8 },
                    { 6, 1, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3790), 1, 1 },
                    { 7, 1, new DateTime(2024, 4, 23, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3792), 2, 5 },
                    { 8, 1, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3794), 1, 7 },
                    { 9, 1, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3796), 1, 8 },
                    { 10, 1, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3798), 1, 1 },
                    { 11, 1, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3800), 2, 5 },
                    { 12, 1, new DateTime(2024, 4, 24, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3802), 2, 10 },
                    { 13, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3803), 3, 7 },
                    { 14, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3805), 1, 8 },
                    { 15, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3807), 1, 1 },
                    { 16, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3809), 2, 5 },
                    { 17, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3810), 2, 10 },
                    { 18, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3812), 3, 13 },
                    { 19, 1, new DateTime(2024, 4, 25, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3814), 3, 14 },
                    { 20, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3816), 1, 7 },
                    { 21, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3818), 1, 8 },
                    { 22, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3819), 1, 1 },
                    { 23, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3821), 2, 5 },
                    { 24, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3823), 2, 10 },
                    { 25, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3825), 3, 13 },
                    { 26, 1, new DateTime(2024, 4, 26, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3827), 3, 14 },
                    { 27, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3828), 1, 7 },
                    { 28, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3830), 1, 8 },
                    { 29, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3832), 1, 1 },
                    { 30, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3834), 2, 5 },
                    { 31, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3835), 2, 10 },
                    { 32, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3837), 2, 12 },
                    { 33, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3839), 3, 13 },
                    { 34, 1, new DateTime(2024, 4, 27, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3841), 3, 14 },
                    { 35, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3842), 1, 7 },
                    { 36, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3844), 1, 8 },
                    { 37, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3846), 1, 1 },
                    { 38, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3847), 2, 5 },
                    { 39, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3849), 2, 10 },
                    { 40, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3851), 2, 12 },
                    { 41, 1, new DateTime(2024, 4, 28, 10, 17, 54, 199, DateTimeKind.Local).AddTicks(3853), 3, 13 }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[] { 1, 4, 14.63m, "1", 1, 26, 369.85m });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[,]
                {
                    { 2, 16, 12m, "2,3,4", 1, 25, 929.28m },
                    { 3, 2, 8.9m, "2a", 1, 24, 68.71m },
                    { 4, 8, 8.9m, "4,8", 1, 24, 128.15m },
                    { 5, 2, 3m, "5", 1, 24, 23.16m },
                    { 6, 8, 1.34m, "6", 1, 18, 9.54m },
                    { 7, 3, 0.65m, "7", 1, 22, 4.82m },
                    { 8, 2, 3.6m, "9", 1, 24, 27.29m },
                    { 9, 105, 6.4m, "12,13", 1, 16, 265.44m },
                    { 10, 4, 18.36m, "1", 2, 26, 470.79m },
                    { 11, 16, 12m, "2,3,4", 2, 25, 929.28m },
                    { 12, 14, 8.15m, "4,8", 2, 25, 552.24m },
                    { 13, 2, 3m, "5", 2, 24, 23.16m },
                    { 14, 8, 1.34m, "6", 2, 18, 9.54m },
                    { 15, 3, 0.65m, "7", 2, 22, 4.82m },
                    { 16, 4, 3.6m, "9", 2, 24, 55.58m },
                    { 17, 135, 6.4m, "12,13", 2, 16, 341.28m },
                    { 18, 4, 18.62m, "1", 3, 26, 470.71m },
                    { 19, 8, 12m, "2,4", 3, 25, 464.64m },
                    { 20, 8, 8.15m, "2,4", 3, 24, 251.67m },
                    { 21, 2, 3m, "5", 3, 24, 23.16m },
                    { 22, 8, 1.34m, "6", 3, 18, 9.54m },
                    { 23, 3, 0.65m, "7", 3, 22, 4.82m },
                    { 24, 6, 3.3m, "8", 3, 22, 48.91m },
                    { 25, 5, 3.7m, "8a", 3, 16, 7.31m },
                    { 26, 4, 3.6m, "9", 3, 24, 55.58m },
                    { 27, 136, 6.4m, "12,13", 3, 16, 343.81m },
                    { 28, 4, 14.67m, "1", 4, 25, 284.01m },
                    { 29, 16, 12m, "2,3,4", 4, 24, 741.12m },
                    { 30, 2, 8.9m, "2a", 4, 24, 68.71m },
                    { 31, 4, 4.15m, "4,8", 4, 24, 64.08m },
                    { 32, 2, 3m, "5", 4, 24, 23.16m },
                    { 33, 8, 1.34m, "6", 4, 18, 9.54m },
                    { 34, 3, 0.65m, "7", 4, 22, 4.82m },
                    { 35, 2, 3.6m, "9", 4, 24, 27.29m },
                    { 36, 105, 6.4m, "12,13", 4, 16, 265.44m },
                    { 37, 4, 14.67m, "1", 5, 26, 370.86m },
                    { 38, 16, 12m, "2,3,4", 5, 24, 741.12m },
                    { 39, 2, 8.9m, "2a", 5, 24, 68.71m },
                    { 40, 4, 4.15m, "4,8", 5, 24, 64.08m },
                    { 41, 2, 3m, "5", 5, 24, 23.16m },
                    { 42, 8, 1.34m, "6", 5, 18, 9.54m },
                    { 43, 3, 0.65m, "7", 5, 22, 4.82m }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[,]
                {
                    { 44, 2, 3.6m, "9", 5, 24, 27.29m },
                    { 45, 105, 6.4m, "12,13", 5, 16, 265.44m },
                    { 46, 4, 14.67m, "1", 6, 26, 370.86m },
                    { 47, 16, 12m, "2,3,4", 6, 24, 741.12m },
                    { 48, 2, 8.9m, "2a", 6, 24, 68.71m },
                    { 49, 12, 4.15m, "4,8", 6, 24, 192.23m },
                    { 50, 2, 3m, "5", 6, 24, 23.16m },
                    { 51, 8, 1.34m, "6", 6, 18, 9.54m },
                    { 52, 3, 0.65m, "7", 6, 22, 4.82m },
                    { 53, 2, 3.6m, "9", 6, 24, 27.29m },
                    { 54, 105, 6.4m, "12,13", 6, 16, 265.44m },
                    { 55, 24, 4.33m, "1", 7, 20, 164.19m },
                    { 56, 9, 5.88m, "2", 7, 18, 64.03m },
                    { 57, 12, 1.93m, "3", 7, 22, 57.21m },
                    { 58, 24, 1.93m, "4", 7, 19, 56.05m },
                    { 59, 3, 1.1m, "5", 7, 26, 20.86m },
                    { 60, 24, 4.88m, "1", 8, 20, 169.88m },
                    { 61, 9, 6.28m, "2", 8, 18, 68.39m },
                    { 62, 12, 2.03m, "3", 8, 22, 60.17m },
                    { 63, 24, 1.93m, "4", 8, 19, 56.05m },
                    { 64, 3, 1.1m, "5", 8, 26, 20.86m },
                    { 65, 3, 1m, "1", 9, 26, 18.96m },
                    { 66, 40, 4.22m, "2", 9, 18, 150.23m },
                    { 67, 64, 0.4m, "3", 9, 16, 10.11m },
                    { 68, 32, 2.03m, "4", 9, 18, 57.81m },
                    { 69, 8, 6.68m, "5", 9, 18, 47.56m },
                    { 70, 5, 6.68m, "6", 9, 19, 40.41m },
                    { 71, 20, 2.13m, "7", 9, 19, 51.55m },
                    { 72, 16, 12.5m, "1", 10, 23, 598m },
                    { 73, 4, 11m, "2", 10, 23, 131.56m },
                    { 74, 12, 2.8m, "3", 10, 22, 82.99m },
                    { 75, 78, 6.92m, "4,5", 10, 16, 213.21m },
                    { 76, 156, 2.06m, "5", 10, 16, 126.94m },
                    { 77, 11, 2m, "6", 10, 16, 8.69m },
                    { 78, 4, 0.92m, "7", 10, 16, 4m },
                    { 79, 4, 5m, "8", 10, 20, 31.6m },
                    { 80, 10, 3m, "9", 10, 20, 47.4m },
                    { 81, 8, 2.6m, "10", 10, 16, 8.22m },
                    { 82, 22, 2.6m, "11", 10, 16, 22.59m },
                    { 83, 44, 0.4m, "12", 10, 16, 6.95m },
                    { 84, 44, 12.96m, "1", 11, 23, 620.01m },
                    { 85, 4, 11.46m, "2", 11, 23, 137.06m }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[,]
                {
                    { 86, 8, 2.8m, "3", 11, 22, 55.33m },
                    { 87, 81, 6.92m, "4,5", 11, 16, 221.41m },
                    { 88, 162, 2.06m, "5", 11, 16, 131.82m },
                    { 89, 11, 2m, "6", 11, 16, 8.69m },
                    { 90, 11, 0.92m, "7", 11, 16, 4m },
                    { 91, 4, 5m, "8", 11, 20, 31.6m },
                    { 92, 10, 3m, "9", 11, 20, 47.4m },
                    { 93, 8, 2.6m, "10", 11, 16, 8.22m },
                    { 94, 22, 2.6m, "11", 11, 16, 22.59m },
                    { 95, 44, 0.4m, "12", 11, 16, 6.95m },
                    { 96, 4, 14m, "1", 12, 22, 138.32m },
                    { 97, 2, 11.35m, "2", 12, 22, 56.07m },
                    { 98, 4, 6.3m, "3", 12, 22, 562.44m },
                    { 99, 4, 14m, "4", 12, 24, 216.16m },
                    { 100, 2, 10.85m, "5", 12, 24, 167.52m },
                    { 101, 14, 14m, "6", 12, 17, 121.52m },
                    { 102, 14, 10.85m, "7", 12, 17, 94.18m },
                    { 103, 4, 14m, "8", 12, 20, 88.48m },
                    { 104, 2, 10m, "9", 12, 20, 31.6m },
                    { 105, 2, 11.35m, "10", 12, 20, 35.87m },
                    { 106, 2, 2.6m, "11", 12, 21, 10.4m },
                    { 107, 2, 3.23m, "12", 12, 21, 12.92m },
                    { 108, 7, 2.23m, "13", 12, 19, 18.89m },
                    { 109, 4, 3.7m, "14", 12, 22, 36.56m },
                    { 110, 8, 3.64m, "15", 12, 16, 11.5m },
                    { 111, 128, 4.78m, "16,20", 12, 16, 241.68m },
                    { 112, 10, 3.6m, "17", 12, 16, 14.22m },
                    { 113, 10, 4.72m, "18,20", 12, 16, 18.64m },
                    { 114, 126, 1.83m, "19", 12, 16, 91.08m },
                    { 115, 36, 0.44m, "21", 12, 16, 5.69m },
                    { 116, 292, 0.2m, "22", 12, 16, 23.07m },
                    { 117, 7, 3.13m, "23", 12, 19, 26.51m },
                    { 118, 2, 3m, "24", 12, 21, 12m },
                    { 119, 2, 4.03m, "25", 12, 21, 16.12m },
                    { 120, 8, 7.36m, "26", 12, 16, 23.26m },
                    { 121, 2, 9m, "27", 12, 16, 7.11m },
                    { 122, 2, 11m, "28", 12, 16, 8.69m },
                    { 123, 2, 8.9m, "1", 13, 21, 35.6m },
                    { 124, 2, 8.9m, "2", 13, 17, 11.04m },
                    { 125, 2, 10.15m, "3", 13, 17, 12.59m },
                    { 126, 2, 2.31m, "4", 13, 19, 5.59m },
                    { 127, 2, 5.11m, "5", 13, 19, 12.37m }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[,]
                {
                    { 128, 2, 1.61m, "6", 13, 17, 2m },
                    { 129, 14, 1.77m, "7,8", 13, 16, 9.79m },
                    { 130, 74, 2.37m, "8,10", 13, 16, 69.28m },
                    { 131, 90, 0.35m, "9", 13, 16, 12.59m },
                    { 132, 2, 4.41m, "11", 13, 19, 10.67m },
                    { 133, 5, 1.56m, "12", 13, 16, 3.08m },
                    { 134, 2, 1.33m, "13", 13, 16, 1.58m },
                    { 135, 2, 1.9m, "14", 13, 18, 3.38m },
                    { 136, 2, 8.95m, "1", 14, 21, 35.8m },
                    { 137, 2, 8.95m, "2", 14, 17, 11.1m },
                    { 138, 2, 10.15m, "3", 14, 17, 12.59m },
                    { 139, 2, 2.31m, "4", 14, 19, 5.59m },
                    { 140, 2, 5.11m, "5", 14, 19, 12.37m },
                    { 141, 2, 1.61m, "6", 14, 17, 2m },
                    { 142, 14, 1.77m, "7,8", 14, 16, 9.79m },
                    { 143, 75, 2.37m, "8,10", 14, 16, 70.21m },
                    { 144, 90, 0.35m, "9", 14, 16, 12.44m },
                    { 145, 2, 4.41m, "11", 14, 19, 10.67m },
                    { 146, 5, 1.56m, "12", 14, 16, 3.08m },
                    { 147, 4, 10.15m, "13", 14, 20, 64.15m },
                    { 148, 2, 2.18m, "14", 14, 19, 5.28m },
                    { 149, 2, 1.9m, "15", 14, 19, 3.38m },
                    { 150, 6, 6.62m, "1", 15, 18, 35.35m },
                    { 151, 5, 6.62m, "2", 15, 21, 66.20m },
                    { 152, 12, 5.72m, "3", 15, 18, 61.09m },
                    { 153, 10, 4.64m, "4", 15, 21, 92.8m },
                    { 154, 32, 4.36m, "5", 15, 18, 124.17m },
                    { 155, 3, 1.35m, "6", 15, 26, 25.6m },
                    { 156, 6, 5.42m, "1", 16, 18, 28.94m },
                    { 157, 5, 5.42m, "2", 16, 19, 32.79m },
                    { 158, 12, 4.64m, "3", 16, 18, 49.56m },
                    { 159, 10, 4.64m, "4", 16, 19, 56.14m },
                    { 160, 24, 4.36m, "5", 16, 18, 93.13m },
                    { 161, 3, 1.35m, "6", 16, 26, 25.6m },
                    { 162, 56, 1.75m, "1", 17, 16, 38.71m },
                    { 163, 12, 9.2m, "2,4", 17, 23, 330.1m },
                    { 164, 11, 9.2m, "3", 17, 21, 202.4m },
                    { 165, 2, 1.44m, "5", 17, 19, 3.48m },
                    { 166, 4, 2.71m, "6", 17, 21, 21.68m },
                    { 167, 2, 2.98m, "7", 17, 21, 11.92m },
                    { 168, 2, 1.93m, "8", 17, 21, 7.72m },
                    { 169, 77, 1.67m, "9", 17, 18, 114.45m }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[,]
                {
                    { 170, 77, 4.24m, "10,12", 17, 18, 290.57m },
                    { 171, 77, 2.46m, "11", 17, 17, 117.44m },
                    { 172, 6, 2.86m, "13", 17, 21, 34.32m },
                    { 173, 24, 2.12m, "14", 17, 17, 31.55m },
                    { 174, 2, 1.82m, "15", 17, 17, 2.26m },
                    { 175, 2, 2.69m, "16", 17, 19, 6.51m },
                    { 176, 39, 0.65m, "17", 17, 17, 15.72m },
                    { 177, 8, 0.5m, "18", 17, 24, 15.44m },
                    { 178, 64, 3.45m, "1", 18, 16, 38.76m },
                    { 179, 8, 9.2m, "2", 18, 24, 284.1m },
                    { 180, 12, 9.2m, "3", 18, 21, 220.8m },
                    { 181, 4, 9.20m, "4", 18, 23, 110.03m },
                    { 182, 4, 1.44m, "5", 18, 19, 6.97m },
                    { 183, 4, 2.71m, "6", 18, 21, 21.68m },
                    { 184, 2, 2.23m, "7", 18, 21, 8.92m },
                    { 185, 2, 1.93m, "8", 18, 21, 7.72m },
                    { 186, 77, 1.67m, "9", 18, 18, 114.45m },
                    { 187, 77, 4.02m, "10,12", 18, 18, 275.49m },
                    { 188, 77, 2.66m, "11", 18, 17, 126.99m },
                    { 189, 12, 1.9m, "13", 18, 21, 45.6m },
                    { 190, 6, 3.23m, "13a", 18, 17, 38.76m },
                    { 191, 24, 2.12m, "14", 18, 17, 31.55m },
                    { 192, 39, 0.65m, "15", 18, 17, 15.72m },
                    { 193, 8, 0.5m, "16", 18, 24, 15.44m },
                    { 194, 2, 10.10m, "1", 19, 19, 24.44m },
                    { 195, 4, 10.90m, "2", 19, 19, 52.76m },
                    { 196, 3, 10.10m, "3", 19, 21, 60.6m },
                    { 197, 3, 10.90m, "4", 19, 21, 65.4m },
                    { 198, 8, 2.42m, "5", 19, 20, 30.59m },
                    { 199, 2, 3.12m, "6", 19, 23, 18.66m },
                    { 200, 4, 0.17m, "7", 19, 24, 2.62m },
                    { 201, 146, 0.4m, "8", 19, 16, 23.07m },
                    { 202, 95, 2m, "9", 19, 16, 75.05m },
                    { 203, 18, 1.34m, "10", 19, 16, 9.53m },
                    { 204, 2, 3.46m, "11", 19, 17, 6.16m },
                    { 205, 2, 10m, "1", 20, 19, 24.2m },
                    { 206, 4, 10.9m, "2", 20, 19, 52.76m },
                    { 207, 3, 10m, "3", 20, 21, 60m },
                    { 208, 3, 10.9m, "4", 20, 21, 65.4m },
                    { 209, 8, 2.42m, "5", 20, 20, 30.59m },
                    { 210, 2, 3.12m, "6", 20, 23, 18.66m },
                    { 211, 4, 0.17m, "7", 20, 24, 2.62m }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforce",
                columns: new[] { "Id", "Count", "Length", "Position", "PrecastId", "ReinforceTypeId", "Weight" },
                values: new object[,]
                {
                    { 212, 146, 0.4m, "8", 20, 16, 23.07m },
                    { 213, 94, 2m, "9", 20, 16, 74.26m },
                    { 214, 20, 1.34m, "10", 20, 16, 10.59m },
                    { 215, 2, 3.46m, "11", 20, 17, 6.16m },
                    { 216, 2, 9.65m, "1", 21, 19, 23.35m },
                    { 217, 4, 10.55m, "2", 21, 19, 51.06m },
                    { 218, 3, 9.65m, "3", 21, 21, 57.9m },
                    { 219, 3, 10.95m, "4", 21, 21, 65.7m },
                    { 220, 8, 2.42m, "5", 21, 20, 30.59m },
                    { 221, 2, 3.12m, "6", 21, 23, 18.66m },
                    { 222, 4, 0.17m, "7", 21, 24, 2.62m },
                    { 223, 146, 0.4m, "8", 21, 16, 23.07m },
                    { 224, 89, 2m, "9", 21, 16, 70.31m },
                    { 225, 20, 1.34m, "10", 21, 16, 10.59m },
                    { 226, 2, 3.46m, "11", 21, 17, 6.16m }
                });

            migrationBuilder.InsertData(
                table: "PrecastReinforceOrders",
                columns: new[] { "PrecastId", "ReinforceOrderId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 9 },
                    { 2, 16 },
                    { 5, 4 },
                    { 5, 12 },
                    { 6, 13 },
                    { 6, 20 },
                    { 7, 1 },
                    { 7, 10 },
                    { 8, 2 },
                    { 8, 11 },
                    { 10, 5 },
                    { 10, 14 },
                    { 11, 21 },
                    { 12, 6 },
                    { 13, 7 },
                    { 14, 8 },
                    { 16, 15 },
                    { 19, 17 },
                    { 20, 18 },
                    { 21, 19 }
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
