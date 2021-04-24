using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "to_do_id",
                table: "tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_tags_to_do_id",
                table: "tags",
                column: "to_do_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_todos_to_do_id",
                table: "tags",
                column: "to_do_id",
                principalTable: "todos",
                principalColumn: "to_do_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_todos_to_do_id",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_to_do_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "to_do_id",
                table: "tags");
        }
    }
}
