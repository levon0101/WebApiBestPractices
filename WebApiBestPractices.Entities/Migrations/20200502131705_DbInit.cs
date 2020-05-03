using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiBestPractices.Entities.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<string>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade01"), "Earth", new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Levon Mardanyan" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade02"), "Earth", new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grigori Mardanyan" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountType", "DateCreated", "Id" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c01"), "Tirakal", new DateTime(2020, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("102b566b-ba1f-404c-b2df-e2cde39ade01") });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
