using Microsoft.EntityFrameworkCore.Migrations;

namespace BYUAmazon.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    authorFirst = table.Column<string>(type: "TEXT", nullable: false),
                    authorMiddle = table.Column<string>(type: "TEXT", nullable: true),
                    authorLast = table.Column<string>(type: "TEXT", nullable: false),
                    publisher = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    classification = table.Column<string>(type: "TEXT", nullable: false),
                    category = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    pages = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
