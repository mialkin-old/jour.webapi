using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_tags_tag_id1",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "fk_tags_todos_to_do_id",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_tag_id1",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_to_do_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "tag_id1",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "to_do_id",
                table: "tags");

            migrationBuilder.CreateTable(
                name: "tag_todo",
                columns: table => new
                {
                    tags_tag_id = table.Column<int>(type: "integer", nullable: false),
                    todos_to_do_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_todo", x => new { x.tags_tag_id, x.todos_to_do_id });
                    table.ForeignKey(
                        name: "fk_tag_todo_tags_tags_tag_id",
                        column: x => x.tags_tag_id,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tag_todo_todos_todos_to_do_id",
                        column: x => x.todos_to_do_id,
                        principalTable: "todos",
                        principalColumn: "to_do_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tag_todo_todos_to_do_id",
                table: "tag_todo",
                column: "todos_to_do_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tag_todo");

            migrationBuilder.AddColumn<int>(
                name: "tag_id1",
                table: "tags",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "to_do_id",
                table: "tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_tags_tag_id1",
                table: "tags",
                column: "tag_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tags_to_do_id",
                table: "tags",
                column: "to_do_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_tags_tag_id1",
                table: "tags",
                column: "tag_id1",
                principalTable: "tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_tags_todos_to_do_id",
                table: "tags",
                column: "to_do_id",
                principalTable: "todos",
                principalColumn: "to_do_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
