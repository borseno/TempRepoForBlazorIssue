using Microsoft.EntityFrameworkCore.Migrations;

namespace Votings.Server.DAL.Migrations
{
    public partial class ChangedOnDeleteBehaviorForVotingAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votings_AspNetUsers_AuthorId",
                table: "Votings");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Votings",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_AspNetUsers_AuthorId",
                table: "Votings",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votings_AspNetUsers_AuthorId",
                table: "Votings");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Votings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_AspNetUsers_AuthorId",
                table: "Votings",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
