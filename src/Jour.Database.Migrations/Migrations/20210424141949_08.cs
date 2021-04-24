using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "goals",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "exercises",
                newName: "title");

            migrationBuilder.CreateIndex(
                name: "ix_exercises_title",
                table: "exercises",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_exercises_title",
                table: "exercises");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "goals",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "exercises",
                newName: "name");
        }
    }
}
