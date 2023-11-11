using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStoryServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoryLikes",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoryId1 = table.Column<int>(type: "integer", nullable: false),
                    Like = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryLikes", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_StoryLikes_Stories_StoryId1",
                        column: x => x.StoryId1,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryViews",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoryId1 = table.Column<int>(type: "integer", nullable: false),
                    View = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryViews", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_StoryViews_Stories_StoryId1",
                        column: x => x.StoryId1,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryLikeUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    StoryLikeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryLikeUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryLikeUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryLikeUsers_StoryLikes_StoryLikeId",
                        column: x => x.StoryLikeId,
                        principalTable: "StoryLikes",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryViewUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StoryViewId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryViewUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryViewUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryViewUsers_StoryViews_StoryViewId",
                        column: x => x.StoryViewId,
                        principalTable: "StoryViews",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoryLikeUsers_StoryLikeId",
                table: "StoryLikeUsers",
                column: "StoryLikeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryLikeUsers_UserId",
                table: "StoryLikeUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryLikes_StoryId1",
                table: "StoryLikes",
                column: "StoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_StoryViewUsers_StoryViewId",
                table: "StoryViewUsers",
                column: "StoryViewId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryViewUsers_UserId",
                table: "StoryViewUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryViews_StoryId1",
                table: "StoryViews",
                column: "StoryId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryLikeUsers");

            migrationBuilder.DropTable(
                name: "StoryViewUsers");

            migrationBuilder.DropTable(
                name: "StoryLikes");

            migrationBuilder.DropTable(
                name: "StoryViews");
        }
    }
}
