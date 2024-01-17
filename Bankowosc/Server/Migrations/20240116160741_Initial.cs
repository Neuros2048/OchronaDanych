using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bankowosc.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    ClientNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PeselSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PeselHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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
                    Money = table.Column<decimal>(type: "Money", nullable: false),
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
                    AccountNumberSender = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    AccountNumberReceiver = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
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
