using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class change_type_name_of_personal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("3df8d80e-15a3-4ba3-bcb9-bd45b76ead97"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("73c7b446-332f-4c63-9850-b68117386e57"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("8cbd79cd-3928-4e06-9a63-cada8eb9d4c0"));

            migrationBuilder.DropColumn(
                name: "maxHoursPerDay",
                table: "personal_trainer");

            migrationBuilder.AddColumn<double>(
                name: "MaxMinutesPerDay",
                table: "personal_trainer",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "MaxMinutesPerDay",
                table: "personal_trainer");

            migrationBuilder.AddColumn<int>(
                name: "maxHoursPerDay",
                table: "personal_trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3df8d80e-15a3-4ba3-bcb9-bd45b76ead97"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("73c7b446-332f-4c63-9850-b68117386e57"), "CatracaB" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8cbd79cd-3928-4e06-9a63-cada8eb9d4c0"), "CatracaC" });
        }
    }
}
