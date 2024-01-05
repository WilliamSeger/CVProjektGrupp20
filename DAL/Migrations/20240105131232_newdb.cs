using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47d62a99-b56f-4ee4-ba21-063e5d07fb78", "b70d8d57-213c-49fd-9f0e-1fbebb9390ed" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 5, 14, 12, 31, 701, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 5, 14, 12, 31, 701, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 5, 14, 12, 31, 701, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 5, 14, 12, 31, 701, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 14, 12, 31, 696, DateTimeKind.Local).AddTicks(3815), new DateTime(2024, 1, 5, 14, 12, 31, 696, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 14, 12, 31, 696, DateTimeKind.Local).AddTicks(3887), new DateTime(2024, 1, 5, 14, 12, 31, 696, DateTimeKind.Local).AddTicks(3889) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96421e10-472d-4292-a2ec-ddc3e145b8f4", "c39acc27-d0d2-48db-ba84-c54fb8a52cdc" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 7, 33, 385, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 7, 33, 385, DateTimeKind.Local).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 7, 33, 385, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 5, 13, 7, 33, 385, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 13, 7, 33, 381, DateTimeKind.Local).AddTicks(2227), new DateTime(2024, 1, 5, 13, 7, 33, 381, DateTimeKind.Local).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 13, 7, 33, 381, DateTimeKind.Local).AddTicks(2297), new DateTime(2024, 1, 5, 13, 7, 33, 381, DateTimeKind.Local).AddTicks(2298) });
        }
    }
}
