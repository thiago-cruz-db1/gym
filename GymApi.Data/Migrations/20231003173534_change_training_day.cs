using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class change_training_day : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TrainingDays",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7fbe0af4-8441-4efb-a0b5-7994b78a4b1f"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("82aaf6e1-2a3a-45f1-a6e8-3616de248f78"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c109cd3a-35a7-4368-b006-0389805cc110"), "CatracaB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("7fbe0af4-8441-4efb-a0b5-7994b78a4b1f"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("82aaf6e1-2a3a-45f1-a6e8-3616de248f78"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("c109cd3a-35a7-4368-b006-0389805cc110"));

            migrationBuilder.AlterColumn<int>(
                name: "TrainingDays",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
