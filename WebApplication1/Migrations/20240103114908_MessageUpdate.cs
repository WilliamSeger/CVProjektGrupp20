using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MessageUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Profiles_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Profiles_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9c8d21d-8633-4ae2-bf38-0382daf2aede", "e7cab09e-b010-4097-8762-b1d7cc1475c1" });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Content", "Created", "IsRead", "RecieverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Tjenare mannen!", new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(4980), false, 2, 1 },
                    { 2, "Gott nytt år kompis.", new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(5008), false, 3, 1 },
                    { 3, "Jag måste berätta en grej...", new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(5012), false, 1, 2 },
                    { 4, "Vem är du? Vem är jag? Levande charader...", new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(5014), false, 1, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8408), new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8461), new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.CreateIndex(
                name: "IX_Message_RecieverId",
                table: "Message",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70a557a9-6160-445d-aabd-1859e06ba331", "d9170aa8-9e18-4b38-9276-8c36e29f943b" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 12, 22, 14, 49, 57, 236, DateTimeKind.Local).AddTicks(938), new DateTime(2023, 12, 22, 14, 49, 57, 236, DateTimeKind.Local).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 12, 22, 14, 49, 57, 236, DateTimeKind.Local).AddTicks(992), new DateTime(2023, 12, 22, 14, 49, 57, 236, DateTimeKind.Local).AddTicks(994) });
        }
    }
}
