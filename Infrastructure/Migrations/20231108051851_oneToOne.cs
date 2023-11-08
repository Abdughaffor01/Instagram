using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class oneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ExternalAccounts_ExternalAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalAccounts",
                table: "ExternalAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ExternalAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExternalAccounts");

            migrationBuilder.DropColumn(
                name: "ExternalAccountId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExternalAccounts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalAccounts",
                table: "ExternalAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalAccounts_AspNetUsers_UserId",
                table: "ExternalAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalAccounts_AspNetUsers_UserId",
                table: "ExternalAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalAccounts",
                table: "ExternalAccounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExternalAccounts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExternalAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ExternalAccountId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalAccounts",
                table: "ExternalAccounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ExternalAccountId",
                table: "AspNetUsers",
                column: "ExternalAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ExternalAccounts_ExternalAccountId",
                table: "AspNetUsers",
                column: "ExternalAccountId",
                principalTable: "ExternalAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
