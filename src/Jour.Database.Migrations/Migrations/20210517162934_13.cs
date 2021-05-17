using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "workout_date",
                table: "workouts",
                newName: "workout_date_utc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "workout_date_utc",
                table: "workouts",
                newName: "workout_date");
        }
    }
}
