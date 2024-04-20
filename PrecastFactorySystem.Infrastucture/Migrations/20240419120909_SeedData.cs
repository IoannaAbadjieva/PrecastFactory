using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecastFactorySystem.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AddedOn", "IsDeleted", "Name", "ProdNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 9, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3802), false, "Yung Solent", "24-101" },
                    { 2, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3833), false, "Argus", "24-102" },
                    { 3, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3862), false, "DM", "24-103" },
                    { 4, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3865), false, "Delita", "24-104" }
                });

            migrationBuilder.InsertData(
                table: "ReinforceOrders",
                columns: new[] { "Id", "Count", "DeliverDate", "DelivererId", "DepartmentId", "OrderDate", "PrecastWeight" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4492), 1, 4, new DateTime(2024, 4, 10, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4484), 362.34m },
                    { 2, 6, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4495), 1, 4, new DateTime(2024, 4, 10, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4494), 375.35m },
                    { 3, 4, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4503), 1, 1, new DateTime(2024, 4, 10, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4497), 1826.74m },
                    { 4, 4, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4506), 1, 1, new DateTime(2024, 4, 10, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4504), 1575.52m },
                    { 5, 6, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4509), 1, 2, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4507), 1282.15m },
                    { 6, 4, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4513), 1, 2, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4511), 1590.3m },
                    { 7, 4, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4515), 1, 3, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4514), 261.51m },
                    { 8, 3, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4519), 1, 3, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4518), 258.45m },
                    { 9, 6, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4523), 1, 1, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4521), 1826.74m },
                    { 10, 6, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4526), 1, 4, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4524), 362.34m },
                    { 11, 4, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4529), 1, 4, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4528), 375.35m },
                    { 12, 2, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4532), 1, 2, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4531), 1575.52m },
                    { 13, 2, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4535), 1, 2, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4534), 1703.67m },
                    { 14, 3, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4538), 1, 2, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4537), 1282.15m },
                    { 15, 6, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4541), 1, 4, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4540), 286.16m },
                    { 16, 4, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4544), 1, 1, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4543), 2386.87m },
                    { 17, 3, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4547), 1, 3, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4546), 368.88m },
                    { 18, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4550), 1, 3, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4549), 368.31m },
                    { 19, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4553), 1, 3, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4552), 360.01m },
                    { 20, 4, new DateTime(2024, 4, 20, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4556), 1, 2, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4554), 1703.67m },
                    { 21, 2, new DateTime(2024, 4, 20, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4559), 1, 3, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4557), 1295.08m },
                    { 22, 4, new DateTime(2024, 4, 21, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4562), 1, 2, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4560), 1244.27m },
                    { 23, 4, new DateTime(2024, 4, 21, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4565), 1, 2, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4564), 1411.44m }
                });

            migrationBuilder.InsertData(
                table: "Precast",
                columns: new[] { "Id", "AddedOn", "ConcreteActualAmount", "ConcreteClassId", "ConcreteProjectAmount", "Count", "IsDeleted", "Name", "PrecastTypeId", "ProjectId", "ReinforceProjectWeight" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 5, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3952), 7.22m, 12, 7.32m, 10, false, "K тип 4", 2, 1, 1900m },
                    { 2, new DateTime(2024, 4, 5, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3959), 9.16m, 12, 9.32m, 8, false, "K тип 6", 2, 1, 2412m },
                    { 3, new DateTime(2024, 4, 5, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3963), 6.98m, 12, 7.11m, 6, false, "K тип 5", 2, 1, 1650m },
                    { 4, new DateTime(2024, 4, 5, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3965), 5.16m, 12, 5.32m, 2, false, "K тип 3", 2, 1, 1495m },
                    { 5, new DateTime(2024, 4, 9, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3968), 7.22m, 12, 7.22m, 6, false, "K тип 1", 2, 1, 1560m },
                    { 6, new DateTime(2024, 4, 9, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3971), 7.22m, 12, 7.22m, 6, false, "K 109, K108 тип 2", 2, 1, 1710m },
                    { 7, new DateTime(2024, 4, 9, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3973), 1.61m, 9, 1.61m, 24, false, "СЧ 1", 1, 1, 384m },
                    { 8, new DateTime(2024, 4, 9, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3976), 1.97m, 9, 1.97m, 10, false, "СЧ 1a", 1, 1, 400m },
                    { 9, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3978), 1.61m, 9, 1.61m, 36, false, "MЧ 1", 1, 2, 375m },
                    { 10, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3981), 7.90m, 12, 7.88m, 9, false, "K тип 1,1а,1б", 2, 2, 1291m },
                    { 11, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3983), 7.90m, 12, 7.88m, 5, false, "K тип 2,2а", 2, 2, 1312m },
                    { 12, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3987), 9.6m, 14, 9.54m, 4, false, "ГГ 1", 4, 2, 1620m },
                    { 13, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3989), 1.2m, 14, 1.24m, 4, false, "Ст. 1", 8, 2, 252m },
                    { 14, new DateTime(2024, 4, 12, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3992), 1.25m, 14, 1.24m, 3, false, "Ст.2A,2B", 8, 2, 254m },
                    { 15, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3994), 2.24m, 9, 2.34m, 16, false, "Ч 1", 1, 3, 397m },
                    { 16, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3997), 1.46m, 9, 1.58m, 37, false, "Ч 2", 1, 3, 274m },
                    { 17, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(3999), 4.04m, 14, 4.10m, 12, false, "ПГр.2.1", 4, 3, 1257m },
                    { 18, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4002), 4.54m, 14, 4.72m, 20, false, "ПГр.1.1", 4, 3, 1430m },
                    { 19, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4005), 1.67m, 12, 1.59m, 3, false, "ПС 2.1", 5, 3, 378m },
                    { 20, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4008), 1.65m, 12, 1.59m, 1, false, "ПС 2.2", 5, 3, 374m },
                    { 21, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(4010), 1.65m, 12, 1.59m, 1, false, "ПС 2.3", 5, 3, 364m }
                });

            migrationBuilder.InsertData(
                table: "DepartmentsPrecast",
                columns: new[] { "Id", "Count", "Date", "DepartmentId", "PrecastId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6764), 1, 7 },
                    { 2, 1, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6775), 1, 8 },
                    { 3, 1, new DateTime(2024, 4, 13, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6777), 1, 1 },
                    { 4, 1, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6778), 1, 7 },
                    { 5, 1, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6780), 1, 8 },
                    { 6, 1, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6782), 1, 1 },
                    { 7, 1, new DateTime(2024, 4, 14, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6783), 2, 5 },
                    { 8, 1, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6785), 7, 7 },
                    { 9, 1, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6787), 1, 8 },
                    { 10, 1, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6788), 1, 1 },
                    { 11, 1, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6790), 2, 5 },
                    { 12, 1, new DateTime(2024, 4, 15, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6791), 2, 10 },
                    { 13, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6793), 7, 7 },
                    { 14, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6795), 1, 8 },
                    { 15, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6796), 1, 1 },
                    { 16, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6798), 2, 5 },
                    { 17, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6799), 2, 10 },
                    { 18, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6801), 3, 13 },
                    { 19, 1, new DateTime(2024, 4, 16, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6803), 3, 14 },
                    { 20, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6804), 7, 7 },
                    { 21, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6806), 1, 8 },
                    { 22, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6807), 1, 1 },
                    { 23, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6809), 2, 5 },
                    { 24, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6811), 2, 10 },
                    { 25, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6812), 3, 13 },
                    { 26, 1, new DateTime(2024, 4, 17, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6814), 3, 14 },
                    { 27, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6815), 1, 7 },
                    { 28, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6817), 1, 8 },
                    { 29, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6819), 1, 1 },
                    { 30, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6820), 2, 5 },
                    { 31, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6822), 2, 10 },
                    { 32, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6823), 2, 12 },
                    { 33, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6825), 3, 13 },
                    { 34, 1, new DateTime(2024, 4, 18, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6826), 3, 14 },
                    { 35, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6828), 1, 7 },
                    { 36, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6830), 1, 8 },
                    { 37, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6831), 1, 1 },
                    { 38, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6833), 2, 5 },
                    { 39, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6835), 2, 10 },
                    { 40, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6837), 2, 12 },
                    { 41, 1, new DateTime(2024, 4, 19, 15, 9, 8, 712, DateTimeKind.Local).AddTicks(6838), 3, 13 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DepartmentsPrecast",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "PrecastReinforce",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 6, 20 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 10, 14 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 11, 21 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 13, 7 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 16, 15 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 19, 17 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 20, 18 });

            migrationBuilder.DeleteData(
                table: "PrecastReinforceOrders",
                keyColumns: new[] { "PrecastId", "ReinforceOrderId" },
                keyValues: new object[] { 21, 19 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Precast",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReinforceOrders",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
