using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGameStoresNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageBackground",
                table: "StoreDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StoreDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GameDetailsId",
                table: "GameStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameStores_GameDetailsId",
                table: "GameStores",
                column: "GameDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStores_GameDetails_GameDetailsId",
                table: "GameStores",
                column: "GameDetailsId",
                principalTable: "GameDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStores_GameDetails_GameDetailsId",
                table: "GameStores");

            migrationBuilder.DropIndex(
                name: "IX_GameStores_GameDetailsId",
                table: "GameStores");

            migrationBuilder.DropColumn(
                name: "GameDetailsId",
                table: "GameStores");

            migrationBuilder.AlterColumn<string>(
                name: "ImageBackground",
                table: "StoreDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StoreDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
