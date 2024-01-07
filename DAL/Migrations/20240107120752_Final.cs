using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1c2a0a6b-a97d-4ef6-b4a5-d74135198ed8", "eba1bfd9-e218-4e4d-8e92-590861a62848" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MessagesCount", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1234", 0, "784c791a-e11e-42ef-8509-0fc9b0e9caa2", null, false, false, null, 0, null, null, "1234Abc!", null, false, "afc1b3e3-a2e1-4b81-aa7d-577bb67a91d1", false, "Admin1" },
                    { "12345", 0, "518cb832-0c0a-486e-8b04-b2f32fc639f7", null, false, false, null, 0, null, null, "1234Abc!", null, false, "99b9479b-387c-419e-b8b6-d31128d34b25", false, "Admin2" }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 7, 13, 7, 52, 187, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 7, 13, 7, 52, 187, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 7, 13, 7, 52, 187, DateTimeKind.Local).AddTicks(8922));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 1, 7, 13, 7, 52, 187, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Adress", "Email", "Name", "UserId" },
                values: new object[] { "Väggatan 24", "[\"gustav@hotmail.com\",\"gustav@f\\u00F6retag.se\"]", "Gustav", "1234" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Adress", "Email", "Name", "UserId" },
                values: new object[] { "Husgatan 2", "[\"oru@yahoo.com\",\"oru@arbete.com\"]", "Göran", "12345" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 7, 13, 7, 52, 185, DateTimeKind.Local).AddTicks(1879), new DateTime(2024, 1, 7, 13, 7, 52, 185, DateTimeKind.Local).AddTicks(1925) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 1, 7, 13, 7, 52, 185, DateTimeKind.Local).AddTicks(1960), new DateTime(2024, 1, 7, 13, 7, 52, 185, DateTimeKind.Local).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Experiences", "Phonenumber", "Qualification" },
                values: new object[] { "[\"Professional Gamer\"]", "[\"09342128\",\"091234854\"]", "[\"ASP NET\",\"HTML-master\"]" });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Education", "Experiences", "Qualification" },
                values: new object[] { "[\"KTH\",\"Yalebon\"]", "[\"Google internship\"]", "[\"Fullstack\"]" });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Education", "Experiences", "Phonenumber", "Qualification" },
                values: new object[] { "[\"Harvard\",\"\\u00D6rebro Universitet\"]", "[\"Rest runt jorden\"]", "[\"123891892\",\"666094854\"]", "[\"Fullstack\",\"ASP NET\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1234");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12345");

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
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Adress", "Email", "Name", "UserId" },
                values: new object[] { "väggatan 4", "[\"hall\\u00E5@hotmail.com\",\"hall\\u00E5@f\\u00F6retag.se\"]", "Bongus", "123" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Adress", "Email", "Name", "UserId" },
                values: new object[] { "väggatan 2", "[\"meh@yahoo.com\",\"meh@arbete.com\"]", "Bing", "123" });

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

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Experiences", "Phonenumber", "Qualification" },
                values: new object[] { "[\"Amgus champion\"]", "[\"09348\",\"094854\"]", "[\"bingus\",\"bongus\"]" });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Education", "Experiences", "Qualification" },
                values: new object[] { "[\"Harvardle\",\"Yalebon\"]", "[\"Coding\"]", "[\"bin\",\"bon\"]" });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Education", "Experiences", "Phonenumber", "Qualification" },
                values: new object[] { "[\"FakeHarvard\",\"RealYale\"]", "[\"Bruh\"]", "[\"66609348\",\"666094854\"]", "[\"binguruskus\",\"sibongus\"]" });
        }
    }
}
