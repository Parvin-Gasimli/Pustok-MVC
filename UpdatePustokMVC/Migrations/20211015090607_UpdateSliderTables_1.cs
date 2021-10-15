using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdatePustokMVC.Migrations
{
    public partial class UpdateSliderTables_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Images",
                table: "Sliders",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(155)",
                oldMaxLength: 155);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Sliders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(155)",
                oldMaxLength: 155,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginaLImages",
                table: "Sliders",
                maxLength: 155,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginaLImages",
                table: "Sliders");

            migrationBuilder.AlterColumn<string>(
                name: "Images",
                table: "Sliders",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 155,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Sliders",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
