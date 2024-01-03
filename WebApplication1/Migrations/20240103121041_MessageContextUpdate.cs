using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MessageContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Profiles_RecieverId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Profiles_SenderId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_RecieverId",
                table: "Messages",
                newName: "IX_Messages_RecieverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_RecieverId",
                table: "Messages",
                column: "RecieverId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_RecieverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_SenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverId",
                table: "Message",
                newName: "IX_Message_RecieverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9c8d21d-8633-4ae2-bf38-0382daf2aede", "e7cab09e-b010-4097-8762-b1d7cc1475c1" });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 3, 12, 49, 7, 449, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8408), new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8461), new DateTime(2024, 1, 3, 12, 49, 7, 447, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Profiles_RecieverId",
                table: "Message",
                column: "RecieverId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Profiles_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
