using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exercises_training_training_workout_id",
                table: "exercises");

            migrationBuilder.DropTable(
                name: "training");

            migrationBuilder.RenameColumn(
                name: "training_workout_id",
                table: "exercises",
                newName: "workout_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercises_training_workout_id",
                table: "exercises",
                newName: "ix_exercises_workout_id");

            migrationBuilder.CreateTable(
                name: "workouts",
                columns: table => new
                {
                    workout_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    workout_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workouts", x => x.workout_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_todos_completed_utc",
                table: "todos",
                column: "completed_utc");

            migrationBuilder.AddForeignKey(
                name: "fk_exercises_workouts_workout_id",
                table: "exercises",
                column: "workout_id",
                principalTable: "workouts",
                principalColumn: "workout_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exercises_workouts_workout_id",
                table: "exercises");

            migrationBuilder.DropTable(
                name: "workouts");

            migrationBuilder.DropIndex(
                name: "ix_todos_completed_utc",
                table: "todos");

            migrationBuilder.RenameColumn(
                name: "workout_id",
                table: "exercises",
                newName: "training_workout_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercises_workout_id",
                table: "exercises",
                newName: "ix_exercises_training_workout_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_exercises_training_training_workout_id",
                table: "exercises",
                column: "training_workout_id",
                principalTable: "training",
                principalColumn: "workout_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
