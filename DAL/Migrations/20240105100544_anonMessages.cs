using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class anonMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anonMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anonMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_anonMessages_Profiles_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2fc2fb54-7734-42a1-8edc-23898559ad14", "7b1df32c-64f2-403b-b805-4a3b8e59d180" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 5, 11, 5, 44, 186, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 5, 11, 5, 44, 186, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 5, 11, 5, 44, 186, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 5, 11, 5, 44, 186, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 11, 5, 44, 184, DateTimeKind.Local).AddTicks(8942), new DateTime(2024, 1, 5, 11, 5, 44, 184, DateTimeKind.Local).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 11, 5, 44, 184, DateTimeKind.Local).AddTicks(9001), new DateTime(2024, 1, 5, 11, 5, 44, 184, DateTimeKind.Local).AddTicks(9003) });

            migrationBuilder.CreateIndex(
                name: "IX_anonMessages_RecieverId",
                table: "anonMessages",
                column: "RecieverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anonMessages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f828ad02-6eff-4cd7-826a-00ece378127d", "c5468306-790c-4c6a-b97d-e583a5e4e169" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 4, 16, 44, 26, 512, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 4, 16, 44, 26, 512, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 4, 16, 44, 26, 512, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 4, 16, 44, 26, 512, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5807), new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5847), new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5848) });
        }
    }
}
