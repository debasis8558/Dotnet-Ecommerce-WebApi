using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Backend.Migrations
{
    /// <inheritdoc />
    public partial class shippingStsColadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingStatus",
                table: "Orders");
        }
    }
}
