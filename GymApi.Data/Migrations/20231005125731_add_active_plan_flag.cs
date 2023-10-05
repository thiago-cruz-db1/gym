using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class add_active_plan_flag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "active_plan",
                table: "plans",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("560fb3dc-ad08-4d4f-bac7-9d3fe37fe07b"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cde77067-a69d-4f05-8d3f-853463a43496"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d104642e-2fe1-4d78-ae04-3f660e539859"), "CatracaB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("560fb3dc-ad08-4d4f-bac7-9d3fe37fe07b"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("cde77067-a69d-4f05-8d3f-853463a43496"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("d104642e-2fe1-4d78-ae04-3f660e539859"));

            migrationBuilder.DropColumn(
                name: "active_plan",
                table: "plans");

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
    }
}
