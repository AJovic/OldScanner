using Microsoft.EntityFrameworkCore.Migrations;

namespace OldScanner.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lastMinutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Event = table.Column<string>(nullable: true),
                    SubEvent = table.Column<string>(nullable: true),
                    One = table.Column<string>(nullable: true),
                    X = table.Column<string>(nullable: true),
                    Two = table.Column<string>(nullable: true),
                    Over = table.Column<string>(nullable: true),
                    Under = table.Column<string>(nullable: true),
                    CG = table.Column<string>(nullable: true),
                    NG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lastMinutes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lastMinutes");
        }
    }
}
