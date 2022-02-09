using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.DevChallenge.Api.Migrations
{
    public partial class UpdatePriceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceAmount",
                table: "Prices",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "InstrumentOwner",
                table: "Prices",
                newName: "Owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Prices",
                newName: "PriceAmount");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Prices",
                newName: "InstrumentOwner");
        }
    }
}
