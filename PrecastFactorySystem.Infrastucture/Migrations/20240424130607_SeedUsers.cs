using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Infrastructure.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("13a26afc-8c31-4777-b202-89966774aaa5"), 0, "e361fdd9-1cfd-4024-89c7-3e1a416ebc97", "admin@mail.com", true, "Chief", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPrKfAxEjutoiwCBUVR6JYf1K8wDH1ZkUCi6p/yK0p+xEGGkN1BzlTBaEF+61g58TA==", null, false, "E801157C-76F3-46BE-8A66-CF9E1DFAB816", false, "admin" },
                    { new Guid("344ef066-7d16-480d-b1d3-6face05c7c62"), 0, "ba04aac3-5458-4cee-9123-7ea5fb4e2ca9", "manager@mail.com", true, "General", "Manager", false, null, "MANAGER@MAIL.COM", "MANAGER", "AQAAAAEAACcQAAAAEHBbc9CH1Y093Zva1lMJiI1/h49SfVNcHx6ug4lM8PLpK8Mxro2j8vp1Uq+j8SlVWA==", null, false, "EF63B86E-D936-4754-885A-1AE91ADC2477", false, "manager" },
                    { new Guid("af7811c7-760b-42c4-b3ed-42cd794e5153"), 0, "f05589fe-cbba-430d-b58b-8e484b0e927f", "reinforce@mail.com", true, "Reinforce", "Manager", false, null, "REINFORCE@MAIL.COM", "REINFORCE_MANAGER", "AQAAAAEAACcQAAAAEBLIVKOT/l5cgJKA3FtBkaODPUb9v2Z17ctt386jws5TXjyXCFNEk8cRvxfTedM70A==", null, false, "E81C4315-5F78-4CF3-93A8-35FCA3CABDC7", false, "reinforce_manager" },
                    { new Guid("ed91d639-dfe6-4d7f-9a19-bc8a1f3a1fbe"), 0, "9b90e779-c848-422e-ae41-8f54ef79587d", "production@mail.com", true, "Production", "Manager", false, null, "PRODUCTION@MAIL.COM", "PRODUCTION_MANAGER", "AQAAAAEAACcQAAAAEFNFjVA6Hx6iVrlYcgvxv4iz8FZGKmkwpyennRfI402As5z3VieFxgFURhEMC1pA+A==", null, false, "6EF9DE2C-07DB-477E-8736-AF2C26CC94FB", false, "production_manager" },
                    { new Guid("f8927215-501c-43ab-92da-972bf9934a93"), 0, "3b715dc6-bf22-4525-8039-21300730a5f8", "user@mail.com", true, "Ordinary", "User", false, null, "USER@MAIL.COM", "USER", "AQAAAAEAACcQAAAAENKrVZRqrctTOSfOxTWDScdD6WIHFpkL3Bk1q/0/Qf0Dbtru9+FHsPRgSVxkyuv/gA==", null, false, "8521099D-8327-4BC9-828C-42EB3C15551E", false, "user" }
                });

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 26,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 27,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 28,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 29,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 30,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 31,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 32,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 33,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 34,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 35,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 36,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 37,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 38,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 39,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 40,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 41,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 14,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 15,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 16,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 17,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 18,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 19,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 20,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 21,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedOn",
                value: new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5884), new DateTime(2024, 4, 15, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5877) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5888), new DateTime(2024, 4, 15, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5891), new DateTime(2024, 4, 15, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5894), new DateTime(2024, 4, 15, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5897), new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5901), new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5904), new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5935), new DateTime(2024, 4, 17, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5938), new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5941), new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5945), new DateTime(2024, 4, 18, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5948), new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5952), new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5950) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5955), new DateTime(2024, 4, 19, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5958), new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5956) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 23, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5961), new DateTime(2024, 4, 20, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5959) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5964), new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5962) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5967), new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5970), new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5968) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5973), new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5971) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5976), new DateTime(2024, 4, 21, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5979), new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5982), new DateTime(2024, 4, 22, 16, 6, 5, 968, DateTimeKind.Local).AddTicks(5981) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("13a26afc-8c31-4777-b202-89966774aaa5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("344ef066-7d16-480d-b1d3-6face05c7c62"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af7811c7-760b-42c4-b3ed-42cd794e5153"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed91d639-dfe6-4d7f-9a19-bc8a1f3a1fbe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8927215-501c-43ab-92da-972bf9934a93"));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 26,
                column: "Date",
                value: new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 27,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 28,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 29,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 30,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 31,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 32,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 33,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 34,
                column: "Date",
                value: new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 35,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 36,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 37,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 38,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 39,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 40,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 41,
                column: "Date",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedOn",
                value: new DateTime(2024, 4, 10, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 14,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 15,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 16,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 17,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 18,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 19,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 20,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 21,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2024, 4, 14, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedOn",
                value: new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedOn",
                value: new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedOn",
                value: new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4997), new DateTime(2024, 4, 15, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5000), new DateTime(2024, 4, 15, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5004), new DateTime(2024, 4, 15, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5002) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5007), new DateTime(2024, 4, 15, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5005) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5010), new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5013), new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5012) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5016), new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5046), new DateTime(2024, 4, 17, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5050), new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5048) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5053), new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5056), new DateTime(2024, 4, 18, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5055) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5058) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5063), new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5066), new DateTime(2024, 4, 19, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5069), new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 23, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5072), new DateTime(2024, 4, 20, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5076), new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5079), new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5082), new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5085), new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5088), new DateTime(2024, 4, 21, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5091), new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeliverDate", "OrderDate" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5094), new DateTime(2024, 4, 22, 16, 1, 10, 178, DateTimeKind.Local).AddTicks(5092) });
        }
    }
}
