using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MessageCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessagesCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "MessagesCount", "SecurityStamp" },
                values: new object[] { "5ba7a9fe-4bc5-470a-a57f-88482e9ebe29", 0, "e113e03c-a695-4cd4-b993-ab2458d9a130" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 6, 12, 1, 18, 530, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 6, 12, 1, 18, 530, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 6, 12, 1, 18, 530, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 6, 12, 1, 18, 530, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 6, 12, 1, 18, 529, DateTimeKind.Local).AddTicks(3254), new DateTime(2024, 1, 6, 12, 1, 18, 529, DateTimeKind.Local).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 6, 12, 1, 18, 529, DateTimeKind.Local).AddTicks(3302), new DateTime(2024, 1, 6, 12, 1, 18, 529, DateTimeKind.Local).AddTicks(3303) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagesCount",
                table: "AspNetUsers");

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
        }
    }
}
