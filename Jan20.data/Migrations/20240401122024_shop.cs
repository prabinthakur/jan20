using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jan20.data.Migrations
{
    /// <inheritdoc />
    public partial class shop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "register",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_register_ShopId",
                table: "register",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_register_shop_ShopId",
                table: "register",
                column: "ShopId",
                principalTable: "shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_register_shop_ShopId",
                table: "register");

            migrationBuilder.DropTable(
                name: "shop");

            migrationBuilder.DropIndex(
                name: "IX_register_ShopId",
                table: "register");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "register");
        }
    }
}
