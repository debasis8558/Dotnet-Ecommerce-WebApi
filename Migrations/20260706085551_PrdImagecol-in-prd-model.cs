using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Backend.Migrations
{
    /// <inheritdoc />
    public partial class PrdImagecolinprdmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImgUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImgUrl",
                table: "Products");
        }
    }
}
