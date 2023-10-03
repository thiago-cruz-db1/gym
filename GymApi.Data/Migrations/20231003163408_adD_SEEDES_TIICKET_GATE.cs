using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class adD_SEEDES_TIICKET_GATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2b920203-7e9b-4b31-83cf-b7b43d0cbe0d"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("513f738c-212e-46e6-b3a9-13e5112869ab"), "CatracaB" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("93e6a9e9-e7bb-4171-97b9-e8039ff8179f"), "CatracaA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("2b920203-7e9b-4b31-83cf-b7b43d0cbe0d"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("513f738c-212e-46e6-b3a9-13e5112869ab"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("93e6a9e9-e7bb-4171-97b9-e8039ff8179f"));
        }
    }
}
