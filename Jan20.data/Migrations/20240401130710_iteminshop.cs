using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jan20.data.Migrations
{
    /// <inheritdoc />
    public partial class iteminshop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_register_shop_ShopId",
                table: "register");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "register",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_ShopId",
                table: "items",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_shop_ShopId",
                table: "items",
                column: "ShopId",
                principalTable: "shop",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_register_shop_ShopId",
                table: "register",
                column: "ShopId",
                principalTable: "shop",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_shop_ShopId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_register_shop_ShopId",
                table: "register");

            migrationBuilder.DropIndex(
                name: "IX_items_ShopId",
                table: "items");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "items");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "register",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_register_shop_ShopId",
                table: "register",
                column: "ShopId",
                principalTable: "shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
