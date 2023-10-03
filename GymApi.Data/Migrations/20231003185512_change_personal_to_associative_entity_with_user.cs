using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Data.Migrations
{
    public partial class change_personal_to_associative_entity_with_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_personal_trainer_PersonalTrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonalTrainerId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "PersonalTrainerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "maxHoursPerDay",
                table: "personal_trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "personal_by_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_by_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_by_user_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personal_by_user_personal_trainer_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "personal_trainer",
                        principalColumn: "personal_trainer_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1cf8a00b-a993-4a60-96b3-2ce851012905"), "CatracaA" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("45f11864-6557-47a5-b876-cb242c99a16c"), "CatracaC" });

            migrationBuilder.InsertData(
                table: "ticket_gate",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c0e180f8-e282-40b5-9e90-02e9b667e089"), "CatracaB" });

            migrationBuilder.CreateIndex(
                name: "IX_personal_by_user_PersonalId",
                table: "personal_by_user",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_by_user_UserId",
                table: "personal_by_user",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personal_by_user");

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("1cf8a00b-a993-4a60-96b3-2ce851012905"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("45f11864-6557-47a5-b876-cb242c99a16c"));

            migrationBuilder.DeleteData(
                table: "ticket_gate",
                keyColumn: "Id",
                keyValue: new Guid("c0e180f8-e282-40b5-9e90-02e9b667e089"));

            migrationBuilder.DropColumn(
                name: "maxHoursPerDay",
                table: "personal_trainer");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonalTrainerId",
                table: "AspNetUsers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonalTrainerId",
                table: "AspNetUsers",
                column: "PersonalTrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_personal_trainer_PersonalTrainerId",
                table: "AspNetUsers",
                column: "PersonalTrainerId",
                principalTable: "personal_trainer",
                principalColumn: "personal_trainer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
