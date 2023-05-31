using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migrations3 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "TariffType",
                table: "Backups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Storages_IdStorage",
                table: "Accounts",
                column: "IdStorage",
                principalTable: "Storages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Tariffs_TariffType",
                table: "Accounts",
                column: "TariffType",
                principalTable: "Tariffs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_IdUser",
                table: "Accounts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Accounts_TariffType",
                table: "Backups",
                column: "TariffType",
                principalTable: "Accounts",
                principalColumn: "TariffType");

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Storages_IdStorage",
                table: "Backups",
                column: "IdStorage",
                principalTable: "Storages",
                principalColumn: "Id");
        }
    }
}
