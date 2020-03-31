using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMEFRAME_api.Migrations
{
    public partial class Update_TimeEntry_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "TimeEntry",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TimeEntry");
        }
    }
}
