using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPractice.Models
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    first_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Authors__3213E83F12B95C4F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Publishe__3213E83FDEAAC3ED", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    first_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    birthday = table.Column<DateTime>(type: "date", nullable: true),
                    pass = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    photo = table.Column<byte[]>(type: "varbinary(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Readers__3213E83FFF35FA6E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    login = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F741D32A3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    number_of_pages = table.Column<int>(type: "int", nullable: true),
                    publisher_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    author_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    published_at = table.Column<DateTime>(type: "date", nullable: true),
                    cover = table.Column<byte[]>(type: "varbinary(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book__3213E83F70E5FFD1", x => x.id);
                    table.ForeignKey(
                        name: "FK__Book__author_id__47DBAE45",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Book__publisher___46E78A0C",
                        column: x => x.publisher_id,
                        principalTable: "Publisher",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BookCopy",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    rack = table.Column<int>(type: "int", nullable: true),
                    shelf = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BookCopy__3213E83F0729BC03", x => x.id);
                    table.ForeignKey(
                        name: "FK__BookCopy__book_i__440B1D61",
                        column: x => x.book_id,
                        principalTable: "Book",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    book_copy_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reader_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taken_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    returned_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    return_to = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Borrowed__3213E83F61C76F76", x => x.id);
                    table.ForeignKey(
                        name: "FK__BorrowedB__book___44FF419A",
                        column: x => x.book_copy_id,
                        principalTable: "BookCopy",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__BorrowedB__reade__45F365D3",
                        column: x => x.reader_id,
                        principalTable: "Readers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_author_id",
                table: "Book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_publisher_id",
                table: "Book",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_book_id",
                table: "BookCopy",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "BorrowedBooks_index_0",
                table: "BorrowedBooks",
                columns: new[] { "book_copy_id", "reader_id", "taken_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_reader_id",
                table: "BorrowedBooks",
                column: "reader_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Readers__8320F63E51E674C8",
                table: "Readers",
                column: "pass",
                unique: true,
                filter: "[pass] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookCopy");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
