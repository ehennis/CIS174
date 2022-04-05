using Microsoft.EntityFrameworkCore.Migrations;

namespace Week11.Migrations
{
    public partial class MoreClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "1548547298");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "8675309");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "Books",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Michelle", "Alexander" },
                    { 2, "Tommy", "TuTone" },
                    { 3, "Seth", "Grahame-Smith" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "Pop", "Pop" },
                    { "History", "History" },
                    { "Novel", "Novel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "GenreId", "ISBN", "Price", "Title" },
                values: new object[] { 1, "Pop", "8675309", 10.0, "Jenny" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "GenreId", "ISBN", "Price", "Title" },
                values: new object[] { 2, "History", "1548547298", 20.0, "The Hobbit" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "GenreId", "ISBN", "Price", "Title" },
                values: new object[] { 3, "Novel", "555", 9.5700000000000003, "Harry Potter" });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenreId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "ISBN");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "1548547298",
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "8675309",
                column: "Price",
                value: 0.0);
        }
    }
}
