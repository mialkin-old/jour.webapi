using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exercises_workouts_workout_id",
                table: "exercises");

            migrationBuilder.DropIndex(
                name: "ix_exercises_workout_id",
                table: "exercises");

            migrationBuilder.DropColumn(
                name: "workout_id",
                table: "exercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "workout_id",
                table: "exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_exercises_workout_id",
                table: "exercises",
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
