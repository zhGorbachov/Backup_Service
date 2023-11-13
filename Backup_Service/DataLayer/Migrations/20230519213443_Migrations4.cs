using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migrations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Storages_IdStorage",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Tariffs_TariffType",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Backups_Accounts_TariffType",
                table: "Backups");

            migrationBuilder.DropForeignKey(
                name: "FK_Backups_Storages_IdStorage",
                table: "Backups");

            migrationBuilder.AlterColumn<int>(
                name: "TariffType",
                table: "Backups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Path", "TotalSize", "UsedSize" },
                values: new object[,]
                {
                    { 1, "asd", 50m, 15m },
                    { 2, "zxczxc", 2222m, 123m }
                });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "BackupSize", "Price", "TariffName" },
                values: new object[,]
                {
                    { 1, 100m, 15m, "Normal" },
                    { 2, 50m, 3m, "Pozer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "zzz", "Sobaka", "123", "Sob" },
                    { 2, "zzz", "Cot", "123", "Co" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "IdStorage", "IdUser", "Login", "Password", "TariffType" },
                values: new object[,]
                {
                    { 1, 1, null, "Sobaka", "Sob", 1 },
                    { 2, 1, null, "Cot", "Co", 2 }
                });

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreationTime", "IdStorage", "Name", "Size", "TariffType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 20, 0, 34, 43, 746, DateTimeKind.Local).AddTicks(504), null, "Sobaka123", 150m, 1 },
                    { 2, new DateTime(2023, 5, 20, 0, 34, 43, 746, DateTimeKind.Local).AddTicks(538), null, "Cot123", 150m, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Storages_IdStorage",
                table: "Accounts",
                column: "IdStorage",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Tariffs_TariffType",
                table: "Accounts",
                column: "TariffType",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Accounts_TariffType",
                table: "Backups",
                column: "TariffType",
                principalTable: "Accounts",
                principalColumn: "TariffType",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Storages_IdStorage",
                table: "Backups",
                column: "IdStorage",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Storages_IdStorage",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Tariffs_TariffType",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Backups_Accounts_TariffType",
                table: "Backups");

            migrationBuilder.DropForeignKey(
                name: "FK_Backups_Storages_IdStorage",
                table: "Backups");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "TariffType",
                table: "Backups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Storages_IdStorage",
                table: "Accounts",
                column: "IdStorage",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Tariffs_TariffType",
                table: "Accounts",
                column: "TariffType",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Accounts_TariffType",
                table: "Backups",
                column: "TariffType",
                principalTable: "Accounts",
                principalColumn: "TariffType",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Storages_IdStorage",
                table: "Backups",
                column: "IdStorage",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
