using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogy.DataAccessLayer.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Writers_WriterId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Articles_WriterId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_WriterId",
                table: "Articles",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Writers_WriterId",
                table: "Articles",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
