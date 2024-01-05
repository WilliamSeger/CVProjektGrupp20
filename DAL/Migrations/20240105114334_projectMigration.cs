using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class projectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Projects_ProjectId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProjectId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => new { x.ProjectId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_Participants_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ProfileId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ProjectOwnerId", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9008), 1, new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ProjectOwnerId", "Updated" },
                values: new object[] { new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9062), 2, new DateTime(2024, 1, 5, 12, 43, 34, 10, DateTimeKind.Local).AddTicks(9064) });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ProfileId",
                table: "Participants",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Profiles_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Profiles_ProjectOwnerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectOwnerId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Profiles",
                type: "int",
                nullable: true);

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
                column: "ProjectId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProjectId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProjectId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ProjectOwnerId", "Updated" },
                values: new object[] { new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5807), 0, new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ProjectOwnerId", "Updated" },
                values: new object[] { new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5847), 0, new DateTime(2024, 1, 4, 16, 44, 26, 511, DateTimeKind.Local).AddTicks(5848) });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProjectId",
                table: "Profiles",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Projects_ProjectId",
                table: "Profiles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
