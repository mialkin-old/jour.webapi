using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.WebAPI.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_goal_tag_tag_tags_tag_id",
                table: "goal_tag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tag",
                table: "tag");

            migrationBuilder.RenameTable(
                name: "tag",
                newName: "tags");

            migrationBuilder.RenameIndex(
                name: "ix_tag_title",
                table: "tags",
                newName: "ix_tags_title");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tags",
                table: "tags",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "fk_goal_tag_tags_tags_tag_id",
                table: "goal_tag",
                column: "tags_tag_id",
                principalTable: "tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_goal_tag_tags_tags_tag_id",
                table: "goal_tag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tags",
                table: "tags");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "tag");

            migrationBuilder.RenameIndex(
                name: "ix_tags_title",
                table: "tag",
                newName: "ix_tag_title");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tag",
                table: "tag",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "fk_goal_tag_tag_tags_tag_id",
                table: "goal_tag",
                column: "tags_tag_id",
                principalTable: "tag",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
