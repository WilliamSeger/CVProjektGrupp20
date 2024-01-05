using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70a557a9-6160-445d-aabd-1859e06ba331", "d9170aa8-9e18-4b38-9276-8c36e29f943b" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPrivate",
                value: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dbb87594-889f-42f7-b476-e49bf7f2b0c6", "f1c60616-03eb-4305-9ff4-772a7c9227da" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPrivate",
                value: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 12, 22, 11, 58, 43, 664, DateTimeKind.Local).AddTicks(9686), new DateTime(2023, 12, 22, 11, 58, 43, 664, DateTimeKind.Local).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 12, 22, 11, 58, 43, 664, DateTimeKind.Local).AddTicks(9740), new DateTime(2023, 12, 22, 11, 58, 43, 664, DateTimeKind.Local).AddTicks(9742) });
        }
    }
}
