using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucid_Scribe.Data.Migrations
{
    public partial class PeoplePlaceObjectSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Objects",
                table: "Dreams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "People",
                table: "Dreams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Places",
                table: "Dreams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Objects",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "People",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "Places",
                table: "Dreams");
        }
    }
}
