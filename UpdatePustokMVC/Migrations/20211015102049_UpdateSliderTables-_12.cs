using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdatePustokMVC.Migrations
{
    public partial class UpdateSliderTables_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Sliders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Sliders");
        }
    }
}
