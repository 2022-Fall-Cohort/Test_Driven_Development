using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Workshop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCharacters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    MainCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MainCharacters",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mario" });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "EmployeeCount", "Name" },
                values: new object[] { 1, 6500, "Nintendo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Platformer" });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "MainCharacterId", "StudioId", "Title" },
                values: new object[] { 1, 1, 1, "Super Mario Brothers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainCharacters");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "VideoGames");
        }
    }
}
