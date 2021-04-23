using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "birthdays",
                columns: table => new
                {
                    birthday_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_birthdays", x => x.birthday_id);
                });

            migrationBuilder.CreateTable(
                name: "goals",
                columns: table => new
                {
                    goal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goals", x => x.goal_id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "to_dos",
                columns: table => new
                {
                    to_do_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_utc = table.Column<DateTime>(type: "date", nullable: false),
                    completed_utc = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_to_dos", x => x.to_do_id);
                });

            migrationBuilder.CreateTable(
                name: "training",
                columns: table => new
                {
                    workout_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    workout_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_training", x => x.workout_id);
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
                        name: "fk_goal_tag_tags_tags_tag_id",
                        column: x => x.tags_tag_id,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    training_workout_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercises", x => x.exercise_id);
                    table.ForeignKey(
                        name: "fk_exercises_training_training_workout_id",
                        column: x => x.training_workout_id,
                        principalTable: "training",
                        principalColumn: "workout_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_exercises_training_workout_id",
                table: "exercises",
                column: "training_workout_id");

            migrationBuilder.CreateIndex(
                name: "ix_goal_tag_tags_tag_id",
                table: "goal_tag",
                column: "tags_tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_title",
                table: "tags",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "birthdays");

            migrationBuilder.DropTable(
                name: "exercises");

            migrationBuilder.DropTable(
                name: "goal_tag");

            migrationBuilder.DropTable(
                name: "to_dos");

            migrationBuilder.DropTable(
                name: "training");

            migrationBuilder.DropTable(
                name: "goals");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
