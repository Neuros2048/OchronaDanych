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
                    { 1L, "4732129813", new DateTime(2024, 1, 20, 22, 23, 7, 24, DateTimeKind.Local).AddTicks(6222), "Gx84vi7an4iK6BmOm334XMX3IH5F/aW2P84sWzh1FQg=", new byte[] { 155, 14, 174, 156, 139, 120, 152, 214, 15, 2, 60, 23, 213, 243, 114, 48 }, "$2a$16$9y7PkkwBhYZC3KaQuB2AM.1w47pi69/cckSr6LRkl4D3gM8kCajFa", "h/TP+QtRpmtu2T5tkJ9shA==", "LeFTYBzYJ+m+h26PMvfM6A==", 0, "9WBPXLhjhRk+OYhoUYC2dA==" },
                    { 2L, "3718005120", new DateTime(2024, 1, 20, 22, 23, 7, 24, DateTimeKind.Local).AddTicks(6792), "+LjXFJQO+q4wXUJDVtUPlVO//0ruad9wNVGTb3EZE6E=", new byte[] { 206, 168, 122, 253, 6, 190, 136, 102, 32, 114, 214, 238, 245, 222, 40, 229 }, "$2a$16$etnQx9rN9xWFZvyPmloOSeRua0.sXjMiIMyf5dAfBGckfs3Fo.a8e", "f7/VzVDBjpAaePN6mmAeig==", "DyMgSOXz4NYukHpROqUcfg==", 0, "soe0O9Fj6z/7PJIiS2RHJw==" },
                    { 3L, "9381230124", new DateTime(2024, 1, 20, 22, 23, 7, 24, DateTimeKind.Local).AddTicks(6992), "uusALUpz7Fp6lFfnWjETeFVcm9DF++ONe2GiD1OHA0g=", new byte[] { 89, 245, 34, 7, 191, 201, 143, 39, 85, 47, 227, 36, 161, 9, 0, 23 }, "$2a$16$Uh3cuvQzs3oe60TzDDR9q.Zli525RGU5rtyDLDoIRI7vrK6ogVWZG", "u0pcUwhbqY8B38omuJ2XKA==", "NMn+dC4F09zDeLStmRzr1w==", 0, "0Eeyw5zZ0fq1W50FNrnDGg==" }
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
                    { 1L, 1L, "kpRVh0i8H4BXEgEyRU0aeQ==", new byte[] { 153, 245, 155, 31, 14, 55, 101, 63, 177, 191, 218, 239, 51, 57, 33, 4 }, "LATA131BSg8+qZmtF50ERg==", "MDL9UXLBce3lwScpGoIZKALpd3qKf7xHjR5puyJjb08=", "$2a$16$AtVSqRtjtQPvgVZkQeEsL.DNZ/af6uE7khAw49.q75tI41sKqpaNq", "HaUuvgvTfnhyF7+Axyqx0Q==" },
                    { 2L, 2L, "9q0RgbQfkIkxLR/LlPQwKg==", new byte[] { 161, 93, 0, 15, 146, 171, 37, 133, 28, 69, 108, 214, 112, 192, 190, 98 }, "sCxwM+G3IfiHUq3GlVQWGA==", "zNemxMOTzdAU6Eq0kK+h9yxi9qYw54jIgbYl0rEK7no=", "$2a$16$VOxlSpEafYjbrBISipCazOPhYQng/hZvkE8EWyDCcP4rTEkFu5b8O", "6JFiaRi61MtsHvi5VIXbFw==" },
                    { 3L, 3L, "3AJssOfBa36un3HX9AHKuQ==", new byte[] { 174, 129, 207, 178, 55, 46, 135, 8, 163, 238, 68, 104, 100, 193, 135, 242 }, "OLKQcYA9b5KJ9AqSNNV7eg==", "Bq9CaZUYWZCaiV9uFNvZdFGwkTt5CPRyi/HbJgR/N2E=", "$2a$16$.VvJNl6dTawR3kWGcvj4GejYNOIsyuecVNOOlMJL5Z/GqTFpGziSC", "Fg7UAw6A34R/jO0B5Cyqhw==" }
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
