using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RatingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowing_AspNetUsers_ObserverId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowing_AspNetUsers_TargetId",
                table: "UserFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowing",
                table: "UserFollowings");




            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings",
                columns: new[] { "ObserverId", "TargetId" });

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    ObserverId = table.Column<string>(type: "TEXT", nullable: false),
                    TargetId = table.Column<string>(type: "TEXT", nullable: false),
                    Feedback = table.Column<string>(type: "TEXT", nullable: true),
                    RatingValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => new { x.ObserverId, x.TargetId });
                    table.ForeignKey(
                        name: "FK_UserRatings_AspNetUsers_ObserverId",
                        column: x => x.ObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatings_AspNetUsers_TargetId",
                        column: x => x.TargetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_TargetId",
                table: "UserRatings",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ObserverId",
                table: "UserFollowings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_TargetId",
                table: "UserFollowings",
                column: "TargetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ObserverId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_TargetId",
                table: "UserFollowings");

            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings");


            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowing",
                table: "UserFollowings",
                columns: new[] { "ObserverId", "TargetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowing_AspNetUsers_ObserverId",
                table: "UserFollowings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowing_AspNetUsers_TargetId",
                table: "UserFollowings",
                column: "TargetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
