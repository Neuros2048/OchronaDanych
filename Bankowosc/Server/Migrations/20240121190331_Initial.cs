using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bankowosc.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LoginAttempts = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    ClientNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Iv = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCredits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iv = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    AcountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCredits_Acounts_AcountId",
                        column: x => x.AcountId,
                        principalTable: "Acounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransacionHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumberSender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumberReceiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Iv = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcountSenderId = table.Column<long>(type: "bigint", nullable: false),
                    AcountReceiverId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacionHistory_Acounts_AcountReceiverId",
                        column: x => x.AcountReceiverId,
                        principalTable: "Acounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacionHistory_Acounts_AcountSenderId",
                        column: x => x.AcountSenderId,
                        principalTable: "Acounts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ClientNumber", "DateCreated", "Email", "Iv", "PasswordHash", "Pesel", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1L, "4732129813", new DateTime(2024, 1, 21, 20, 3, 31, 743, DateTimeKind.Local).AddTicks(160), "zc8wJ7ZvPxGk5lGyXvs1NoH7D/eXmDmceXcvByVuZtc=", new byte[] { 231, 58, 156, 240, 65, 101, 120, 33, 37, 158, 122, 119, 176, 16, 61, 40 }, "$2a$16$6TRN/d4k5iDejsbBWokESebo.guEHPvUtMXM0KqBzbaZhmClQyrH.", "HyjZ/G9t22Y9u1aJ+6MZGA==", "2nAEkLTaTva8tcoiNs6bdw==", 0, "BVfQpFAOn9ae4SZ9rnaOe0WUgQW9qVRkjrDBPXNLOHk=" },
                    { 2L, "3718005120", new DateTime(2024, 1, 21, 20, 3, 31, 743, DateTimeKind.Local).AddTicks(912), "tffoZQtTRYAkKJvMyWCN51bd9whQJtlNvRQnMrO5/KU=", new byte[] { 113, 192, 35, 145, 152, 233, 174, 212, 240, 132, 248, 196, 101, 91, 101, 111 }, "$2a$16$fRunnfJCi/Vi7SauYSoRMO6jfhtO2bquah7XZMJGzdkzZxaTZdHsG", "NQMmBadTcb0VKnSScEmkoQ==", "B9jWJqzXVUN8bzwG0Tz89g==", 0, "kdbYToBGBLydZezRxbjY7A==" },
                    { 3L, "9381230124", new DateTime(2024, 1, 21, 20, 3, 31, 743, DateTimeKind.Local).AddTicks(1074), "h33h6koqZQMLr4Z6A1cffOGkb7BDWi4wUAGNYBxqqIY=", new byte[] { 172, 252, 68, 32, 172, 28, 155, 122, 245, 17, 91, 83, 59, 195, 67, 99 }, "$2a$16$Uh3cuvQzs3oe60TzDDR9q.Zli525RGU5rtyDLDoIRI7vrK6ogVWZG", "uA5Lz8TfbxovcqOedokwLQ==", "3SWqp4COlQlLIdL5zUGV9A==", 0, "luJQHFzZEo0ZhzISTN+ECg==" },
                    { 4L, "4398309612", new DateTime(2024, 1, 21, 20, 3, 31, 743, DateTimeKind.Local).AddTicks(1215), "XVZT7qhxq1SU7xNE9tS4+QModpSmDo57zLu2+PPXWck=", new byte[] { 123, 192, 36, 1, 248, 171, 37, 76, 113, 118, 68, 166, 76, 7, 19, 209 }, "$2a$16$pKK0/EPMqLeDrwcDfU2xMOHUfExqE4ALg13eRv2sU1olmeXXokkxi", "MgRGSvx0a901oKd6sRUlfA==", "YmJige1K8Q/1OZYJUgFiOQ==", 1, "KWeLxXOsNR+2b1FtdF+Te90uZAs7cEHV0v9BSMryiDQ=" }
                });

            migrationBuilder.InsertData(
                table: "Acounts",
                columns: new[] { "Id", "AccountNumber", "Money", "UserId" },
                values: new object[,]
                {
                    { 1L, "11111111111111111111111111", 1000.50m, 1L },
                    { 2L, "11111111111111111111111112", 500.75m, 2L },
                    { 3L, "11111111111111111111111113", 2000.30m, 3L }
                });

            migrationBuilder.InsertData(
                table: "CreditCredits",
                columns: new[] { "Id", "AcountId", "EndDate", "Iv", "Name", "Numbers", "Pin", "SpecialNumber" },
                values: new object[,]
                {
                    { 1L, 1L, "obuXIE1EfRMyZDytXiRRZw==", new byte[] { 132, 232, 151, 124, 148, 101, 125, 142, 245, 82, 216, 243, 100, 62, 137, 178 }, "kVDJ51Ftwhuc7uPwB+Hepg==", "RiHRxCNJ7ekNwF+7/HYr3INYRXVMwrqJAQA1+U++rgo=", "$2a$16$AtVSqRtjtQPvgVZkQeEsL.DNZ/af6uE7khAw49.q75tI41sKqpaNq", "sLZYUMajdj8Zo3cRWiO6fQ==" },
                    { 2L, 2L, "503ATEUPqB5TRZX8jUi7Sg==", new byte[] { 129, 250, 49, 30, 11, 216, 20, 233, 195, 81, 66, 29, 73, 176, 184, 30 }, "hFDYcFEutliMtaltC+T6Jg==", "0LBx8Y+Phg0ULt6Jsy7Wu2xITc4nUgG27TBxM9eXt/Q=", "$2a$16$VOxlSpEafYjbrBISipCazOPhYQng/hZvkE8EWyDCcP4rTEkFu5b8O", "NFgZ1POI3ruOfBQVJaTJjQ==" },
                    { 3L, 3L, "RuKwDsDXTbLmll+Bm/aogA==", new byte[] { 95, 140, 14, 177, 179, 25, 248, 64, 38, 41, 12, 18, 79, 243, 73, 12 }, "AwiePtLQNyP7K+vFZ9a4Tw==", "5TnH0okeB7qCbsEz+63Jq879Lo1ol6QjzMpDOu2ShTM=", "$2a$16$.VvJNl6dTawR3kWGcvj4GejYNOIsyuecVNOOlMJL5Z/GqTFpGziSC", "XfZWqFNb26XjNRLAoFuyTw==" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acounts_AccountNumber",
                table: "Acounts",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acounts_UserId",
                table: "Acounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlockAccounts_UserNumber",
                table: "BlockAccounts",
                column: "UserNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCredits_AcountId",
                table: "CreditCredits",
                column: "AcountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransacionHistory_AcountReceiverId",
                table: "TransacionHistory",
                column: "AcountReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransacionHistory_AcountSenderId",
                table: "TransacionHistory",
                column: "AcountSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientNumber",
                table: "Users",
                column: "ClientNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockAccounts");

            migrationBuilder.DropTable(
                name: "CreditCredits");

            migrationBuilder.DropTable(
                name: "TransacionHistory");

            migrationBuilder.DropTable(
                name: "Acounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
