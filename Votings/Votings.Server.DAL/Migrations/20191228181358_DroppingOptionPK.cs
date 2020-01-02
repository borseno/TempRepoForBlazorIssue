using Microsoft.EntityFrameworkCore.Migrations;

namespace Votings.Server.DAL.Migrations
{
    public partial class DroppingOptionPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Options_OptionId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_AspNetUsers_UserId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Votings_VotingId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choices",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_OptionId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Choices");

            migrationBuilder.AlterColumn<int>(
                name: "VotingId",
                table: "Options",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Choices",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_UserId",
                table: "Choices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_AspNetUsers_UserId",
                table: "Choices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Votings_VotingId",
                table: "Options",
                column: "VotingId",
                principalTable: "Votings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_AspNetUsers_UserId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Votings_VotingId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Choices_UserId",
                table: "Choices");

            migrationBuilder.AlterColumn<int>(
                name: "VotingId",
                table: "Options",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Choices",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "Choices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choices",
                table: "Choices",
                columns: new[] { "UserId", "OptionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_OptionId",
                table: "Choices",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Options_OptionId",
                table: "Choices",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_AspNetUsers_UserId",
                table: "Choices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Votings_VotingId",
                table: "Options",
                column: "VotingId",
                principalTable: "Votings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
