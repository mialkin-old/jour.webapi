using Microsoft.EntityFrameworkCore.Migrations;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_to_dos",
                table: "to_dos");

            migrationBuilder.RenameTable(
                name: "to_dos",
                newName: "todos");

            migrationBuilder.AddPrimaryKey(
                name: "pk_todos",
                table: "todos",
                column: "to_do_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_todos",
                table: "todos");

            migrationBuilder.RenameTable(
                name: "todos",
                newName: "to_dos");

            migrationBuilder.AddPrimaryKey(
                name: "pk_to_dos",
                table: "to_dos",
                column: "to_do_id");
        }
    }
}
