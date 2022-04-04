using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMasked.Migrations.MarketMaskedNft
{
    public partial class Fixmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Nft",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Nft");
        }
    }
}
