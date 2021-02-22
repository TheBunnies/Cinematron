using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinematron.DAL.Migrations
{
    public partial class RenamedDurationforshows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageDuration",
                table: "Shows",
                newName: "Duration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Shows",
                newName: "AverageDuration");
        }
    }
}
