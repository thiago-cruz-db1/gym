using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class add_day_week_plan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("a15aa733-1e5e-4639-bb63-37b54f82a5c7"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("e2722d4f-82e4-4efe-9785-d0c9c3b5ba46"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("fdab9b3f-6c64-4b8a-a1cb-b2bbffa8f99d"));

            migrationBuilder.AddColumn<string>(
                name: "day_of_week_plan",
                table: "plans",
                type: "varchar(45)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "MaxMinutesPerDay",
                table: "personal_trainer",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9aad6a9a-6daf-4001-975f-2da04e0c77f9"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("aaf952e4-1e49-4514-87c4-e5c60afddaf5"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("afce41af-b9ff-4d2d-969a-eb1235a55530"), "CatracaB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("9aad6a9a-6daf-4001-975f-2da04e0c77f9"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("aaf952e4-1e49-4514-87c4-e5c60afddaf5"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("afce41af-b9ff-4d2d-969a-eb1235a55530"));

            migrationBuilder.DropColumn(
                name: "day_of_week_plan",
                table: "plans");

            migrationBuilder.AlterColumn<double>(
                name: "MaxMinutesPerDay",
                table: "personal_trainer",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a15aa733-1e5e-4639-bb63-37b54f82a5c7"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e2722d4f-82e4-4efe-9785-d0c9c3b5ba46"), "CatracaB" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fdab9b3f-6c64-4b8a-a1cb-b2bbffa8f99d"), "CatracaC" });
        }
    }
}
