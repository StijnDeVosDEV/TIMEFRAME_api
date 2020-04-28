using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMEFRAME_api.Migrations
{
    public partial class Add_UserID_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "TimeEntry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "TaskEntry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TimeEntry");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TaskEntry");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Customer");
        }
    }
}
