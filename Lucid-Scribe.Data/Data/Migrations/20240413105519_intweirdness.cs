using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucid_Scribe.Data.Migrations
{
    public partial class intweirdness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weirdness",
                table: "Dreams",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weirdness",
                table: "Dreams",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
