using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.WebAPI.Migrations
{
    public partial class _09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exercises_workouts_workout_id",
                table: "exercises");

            migrationBuilder.DropPrimaryKey(
                name: "pk_workouts",
                table: "workouts");

            migrationBuilder.DropColumn(
                name: "description",
                table: "goals");

            migrationBuilder.RenameTable(
                name: "workouts",
                newName: "training");

            migrationBuilder.RenameColumn(
                name: "workout_id",
                table: "exercises",
                newName: "training_workout_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercises_workout_id",
                table: "exercises",
                newName: "ix_exercises_training_workout_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_training",
                table: "training",
                column: "workout_id");

            migrationBuilder.AddForeignKey(
                name: "fk_exercises_training_training_workout_id",
                table: "exercises",
                column: "training_workout_id",
                principalTable: "training",
                principalColumn: "workout_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exercises_training_training_workout_id",
                table: "exercises");

            migrationBuilder.DropPrimaryKey(
                name: "pk_training",
                table: "training");

            migrationBuilder.RenameTable(
                name: "training",
                newName: "workouts");

            migrationBuilder.RenameColumn(
                name: "training_workout_id",
                table: "exercises",
                newName: "workout_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercises_training_workout_id",
                table: "exercises",
                newName: "ix_exercises_workout_id");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "goals",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_workouts",
                table: "workouts",
                column: "workout_id");

            migrationBuilder.AddForeignKey(
                name: "fk_exercises_workouts_workout_id",
                table: "exercises",
                column: "workout_id",
                principalTable: "workouts",
                principalColumn: "workout_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
