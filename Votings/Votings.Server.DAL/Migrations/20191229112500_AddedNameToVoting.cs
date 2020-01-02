using Microsoft.EntityFrameworkCore.Migrations;

namespace Votings.Server.DAL.Migrations
{
    public partial class AddedNameToVoting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Votings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Votings");
        }
    }
}
