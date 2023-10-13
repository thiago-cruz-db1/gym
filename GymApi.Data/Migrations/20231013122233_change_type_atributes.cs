using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class change_type_atributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("2d6c3e53-40b5-4079-846d-ff3b4464c0eb"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("6fb8cc1c-d096-478f-a594-5200d2077f9b"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("b6e2d105-943f-4026-a2b7-66b55960348b"));

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6d684204-e261-4c31-83dc-8e9da62e755b"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9c1bdd70-f917-4cbc-80af-220ab9989ec8"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f010ce41-8f79-4b65-b8ea-910dcac237c2"), "CatracaB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("6d684204-e261-4c31-83dc-8e9da62e755b"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("9c1bdd70-f917-4cbc-80af-220ab9989ec8"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("f010ce41-8f79-4b65-b8ea-910dcac237c2"));

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2d6c3e53-40b5-4079-846d-ff3b4464c0eb"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6fb8cc1c-d096-478f-a594-5200d2077f9b"), "CatracaB" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b6e2d105-943f-4026-a2b7-66b55960348b"), "CatracaA" });
        }
    }
}
