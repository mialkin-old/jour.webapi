using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "tags",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "tag_id1",
                table: "tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_tags_tag_id1",
                table: "tags",
                column: "tag_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_tags_tag_id1",
                table: "tags",
                column: "tag_id1",
                principalTable: "tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_tags_tag_id1",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_tag_id1",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "tag_id1",
                table: "tags");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "tags",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
