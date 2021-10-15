using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdatePustokMVC.Migrations
{
    public partial class _UpdateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Title = table.Column<string>(maxLength: 220, nullable: true),
                    Images = table.Column<string>(maxLength: 100, nullable: true),
                    HovImages = table.Column<string>(maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Discountprice = table.Column<decimal>(type: "money", nullable: true),
                    IsFeature = table.Column<bool>(nullable: false),
                    IsArrival = table.Column<bool>(nullable: false),
                    IsMost = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
