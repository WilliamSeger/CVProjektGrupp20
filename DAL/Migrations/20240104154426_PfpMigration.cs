using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class PfpMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePicturePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePicturePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfilePicturePath",
                value: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "Profiles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51ba8733-dafb-47d8-8e61-313b3db0b5b8", "39df011d-eba2-4fab-9a19-9cb4d70da27a" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 3, 13, 10, 40, 665, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 3, 13, 10, 40, 665, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 3, 13, 10, 40, 665, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 3, 13, 10, 40, 665, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 3, 13, 10, 40, 663, DateTimeKind.Local).AddTicks(1881), new DateTime(2024, 1, 3, 13, 10, 40, 663, DateTimeKind.Local).AddTicks(1939) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 3, 13, 10, 40, 663, DateTimeKind.Local).AddTicks(1943), new DateTime(2024, 1, 3, 13, 10, 40, 663, DateTimeKind.Local).AddTicks(1945) });
        }
    }
}
