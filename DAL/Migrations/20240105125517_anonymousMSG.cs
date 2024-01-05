using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class anonymousMSG : Migration
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
                values: new object[] { "2a0bb15b-d734-4c4d-af81-30fcd783234b", "60ba611c-526d-4485-b647-a80eebd878e2" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 55, 16, 297, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 55, 16, 297, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 55, 16, 297, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 55, 16, 297, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 13, 55, 16, 292, DateTimeKind.Local).AddTicks(3684), new DateTime(2024, 1, 5, 13, 55, 16, 292, DateTimeKind.Local).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 13, 55, 16, 292, DateTimeKind.Local).AddTicks(3740), new DateTime(2024, 1, 5, 13, 55, 16, 292, DateTimeKind.Local).AddTicks(3742) });

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
                values: new object[] { "2eba916f-bf08-4141-9288-f2e428ae2238", "5d72ec4f-2009-4aa7-a0bc-3ebda38331b0" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 5, 12, 43, 34, 12, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 5, 12, 43, 34, 12, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 5, 12, 43, 34, 12, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 5, 12, 43, 34, 12, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9008), new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9062), new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9064) });
        }
    }
}
