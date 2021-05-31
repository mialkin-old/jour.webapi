using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Jour.Database.Migrations.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "book_id",
                table: "tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    author = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.book_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tags_book_id",
                table: "tags",
                column: "book_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tags_books_book_id",
                table: "tags",
                column: "book_id",
                principalTable: "books",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_books_book_id",
                table: "tags");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropIndex(
                name: "ix_tags_book_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "book_id",
                table: "tags");
        }
    }
}
