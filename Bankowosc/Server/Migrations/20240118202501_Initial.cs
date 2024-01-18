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
                    PeselHash = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
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
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numbers = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SpecialNumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    AcountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Acounts_AcountId",
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
                    AccountNumberSender = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    AccountNumberReceiver = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
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
                columns: new[] { "Id", "ClientNumber", "DateCreated", "Email", "PasswordHash", "PeselHash", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1L, "4732129813", new DateTime(2024, 1, 18, 21, 25, 1, 755, DateTimeKind.Local).AddTicks(2220), "user1@example.com", "$2a$11$/mb61PYFJRcQwpgGyR089ujK0CZEBjQwKKX0unXoZbZVTYG/WW3Jm", "a", "1234567890", 0, "user1" },
                    { 2L, "3718005120", new DateTime(2024, 1, 18, 21, 25, 1, 755, DateTimeKind.Local).AddTicks(2228), "user2@example.com", "$2a$11$aXmxeKeEc.YAJ.xVyv2TReQAPiqIArKtUO7OFJ1QSxpP2Bn.IpPKq", "a", "9876543210", 0, "user2" },
                    { 3L, "9381230124", new DateTime(2024, 1, 18, 21, 25, 1, 755, DateTimeKind.Local).AddTicks(2234), "user3@example.com", "$2a$11$nasG4aM4pQbOM.Rq4i1FBejdUhYEfXwrifah0xwMgffhwmshn.Z/.", "a", "5555555555", 0, "user3" }
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
                name: "IX_Credits_AcountId",
                table: "Credits",
                column: "AcountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_Numbers",
                table: "Credits",
                column: "Numbers",
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
                name: "Credits");

            migrationBuilder.DropTable(
                name: "TransacionHistory");

            migrationBuilder.DropTable(
                name: "Acounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
