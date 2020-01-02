using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Votings.Server.DAL.Migrations
{
    public partial class ChangedOptionPKTypeFromIntToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Options",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Choices",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OptionId",
                table: "Choices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Choices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}
