using Microsoft.EntityFrameworkCore.Migrations;

namespace Votings.Server.DAL.Migrations
{
    public partial class RenamedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVoting");

            migrationBuilder.CreateTable(
                name: "UserVotingStatus",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    VotingId = table.Column<int>(nullable: false),
                    UserStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVotingStatus", x => new { x.UserId, x.VotingId });
                    table.ForeignKey(
                        name: "FK_UserVotingStatus_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVotingStatus_Votings_VotingId",
                        column: x => x.VotingId,
                        principalTable: "Votings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVotingStatus_VotingId",
                table: "UserVotingStatus",
                column: "VotingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVotingStatus");

            migrationBuilder.CreateTable(
                name: "UserVoting",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VotingId = table.Column<int>(type: "int", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVoting", x => new { x.UserId, x.VotingId });
                    table.ForeignKey(
                        name: "FK_UserVoting_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVoting_Votings_VotingId",
                        column: x => x.VotingId,
                        principalTable: "Votings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVoting_VotingId",
                table: "UserVoting",
                column: "VotingId");
        }
    }
}
