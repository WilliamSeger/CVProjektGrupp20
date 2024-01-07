using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class veryNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9878ba78-7eba-4543-a6a6-602780581737", "df12b13e-7d2f-405e-95c7-facb725dfb31" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 30, 12, 314, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 30, 12, 314, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 30, 12, 314, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 30, 12, 314, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 6, 13, 30, 12, 310, DateTimeKind.Local).AddTicks(2447), new DateTime(2024, 1, 6, 13, 30, 12, 310, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 6, 13, 30, 12, 310, DateTimeKind.Local).AddTicks(2505), new DateTime(2024, 1, 6, 13, 30, 12, 310, DateTimeKind.Local).AddTicks(2507) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4cd78b9f-8e5d-472f-aa15-d1659f70e128", "502f4352-e14e-4864-830b-5611e2ff7e41" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 17, 15, 728, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 17, 15, 728, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 17, 15, 728, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 6, 13, 17, 15, 728, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 6, 13, 17, 15, 723, DateTimeKind.Local).AddTicks(2331), new DateTime(2024, 1, 6, 13, 17, 15, 723, DateTimeKind.Local).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 6, 13, 17, 15, 723, DateTimeKind.Local).AddTicks(2392), new DateTime(2024, 1, 6, 13, 17, 15, 723, DateTimeKind.Local).AddTicks(2396) });
        }
    }
}
