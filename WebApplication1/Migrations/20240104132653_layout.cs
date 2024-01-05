using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class layout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessagesCount",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessagesCount",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessagesCount",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessagesCount",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3bc7bf10-57b9-46d9-b186-e0b424612b3b", "0af3a4da-183f-41d4-98ad-9b8dfb7d69df" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "MessagesCount" },
                values: new object[] { new DateTime(2024, 1, 4, 14, 26, 52, 636, DateTimeKind.Local).AddTicks(8217), 0 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "MessagesCount" },
                values: new object[] { new DateTime(2024, 1, 4, 14, 26, 52, 636, DateTimeKind.Local).AddTicks(8257), 0 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "MessagesCount" },
                values: new object[] { new DateTime(2024, 1, 4, 14, 26, 52, 636, DateTimeKind.Local).AddTicks(8260), 0 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "MessagesCount" },
                values: new object[] { new DateTime(2024, 1, 4, 14, 26, 52, 636, DateTimeKind.Local).AddTicks(8263), 0 });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "MessagesCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "MessagesCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "MessagesCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "MessagesCount", "Updated" },
                values: new object[] { new DateTime(2024, 1, 4, 14, 26, 52, 634, DateTimeKind.Local).AddTicks(4948), 0, new DateTime(2024, 1, 4, 14, 26, 52, 634, DateTimeKind.Local).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "MessagesCount", "Updated" },
                values: new object[] { new DateTime(2024, 1, 4, 14, 26, 52, 634, DateTimeKind.Local).AddTicks(5006), 0, new DateTime(2024, 1, 4, 14, 26, 52, 634, DateTimeKind.Local).AddTicks(5008) });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                column: "MessagesCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MessagesCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 3,
                column: "MessagesCount",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagesCount",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "MessagesCount",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MessagesCount",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MessagesCount",
                table: "Messages");

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
