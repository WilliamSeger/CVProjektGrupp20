using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Alexan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ba7a9fe-4bc5-470a-a57f-88482e9ebe29", "e113e03c-a695-4cd4-b993-ab2458d9a130" });

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
    }
}
