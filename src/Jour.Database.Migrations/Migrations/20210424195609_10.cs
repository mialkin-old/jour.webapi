using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tag_todo_todos_todos_to_do_id",
                table: "tag_todo");

            migrationBuilder.RenameColumn(
                name: "to_do_id",
                table: "todos",
                newName: "todo_id");

            migrationBuilder.RenameColumn(
                name: "todos_to_do_id",
                table: "tag_todo",
                newName: "todos_todo_id");

            migrationBuilder.RenameIndex(
                name: "ix_tag_todo_todos_to_do_id",
                table: "tag_todo",
                newName: "ix_tag_todo_todos_todo_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tag_todo_todos_todos_todo_id",
                table: "tag_todo",
                column: "todos_todo_id",
                principalTable: "todos",
                principalColumn: "todo_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tag_todo_todos_todos_todo_id",
                table: "tag_todo");

            migrationBuilder.RenameColumn(
                name: "todo_id",
                table: "todos",
                newName: "to_do_id");

            migrationBuilder.RenameColumn(
                name: "todos_todo_id",
                table: "tag_todo",
                newName: "todos_to_do_id");

            migrationBuilder.RenameIndex(
                name: "ix_tag_todo_todos_todo_id",
                table: "tag_todo",
                newName: "ix_tag_todo_todos_to_do_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tag_todo_todos_todos_to_do_id",
                table: "tag_todo",
                column: "todos_to_do_id",
                principalTable: "todos",
                principalColumn: "to_do_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
