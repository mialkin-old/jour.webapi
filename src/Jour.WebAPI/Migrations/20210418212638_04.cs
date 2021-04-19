using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Jour.WebAPI.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "goal_tag",
                columns: table => new
                {
                    goals_goal_id = table.Column<int>(type: "integer", nullable: false),
                    tags_tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goal_tag", x => new { x.goals_goal_id, x.tags_tag_id });
                    table.ForeignKey(
                        name: "fk_goal_tag_goals_goals_goal_id",
                        column: x => x.goals_goal_id,
                        principalTable: "goals",
                        principalColumn: "goal_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_goal_tag_tag_tags_tag_id",
                        column: x => x.tags_tag_id,
                        principalTable: "tag",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_goal_tag_tags_tag_id",
                table: "goal_tag",
                column: "tags_tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_title",
                table: "tag",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goal_tag");

            migrationBuilder.DropTable(
                name: "tag");
        }
    }
}
