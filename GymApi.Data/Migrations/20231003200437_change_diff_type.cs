using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class change_diff_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("8a1fc260-99e4-4d88-b680-f072b1060886"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("9fb66a7e-c797-46c4-b882-7ae8c709713f"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("ac506c87-069f-449a-a1b7-2116144d3cd0"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8a1fc260-99e4-4d88-b680-f072b1060886"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9fb66a7e-c797-46c4-b882-7ae8c709713f"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ac506c87-069f-449a-a1b7-2116144d3cd0"), "CatracaB" });
        }
    }
}
