using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class newTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19767deb-79c8-4a3c-9a7e-c3ed3a0badf8", "26ba257c-4c17-4bcf-8ce2-4e79c9e1b696" });

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
                values: new object[] { new DateTime(2023, 12, 21, 15, 38, 28, 546, DateTimeKind.Local).AddTicks(2567), new DateTime(2023, 12, 21, 15, 38, 28, 546, DateTimeKind.Local).AddTicks(2624) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 12, 21, 15, 38, 28, 546, DateTimeKind.Local).AddTicks(2626), new DateTime(2023, 12, 21, 15, 38, 28, 546, DateTimeKind.Local).AddTicks(2628) });
        }
    }
}
