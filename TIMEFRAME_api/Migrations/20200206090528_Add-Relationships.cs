using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMEFRAME_api.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskEntryId",
                table: "TimeEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TaskEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntry_TaskEntryId",
                table: "TimeEntry",
                column: "TaskEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntry_ProjectId",
                table: "TaskEntry",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntry_Project_ProjectId",
                table: "TaskEntry",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntry_TaskEntry_TaskEntryId",
                table: "TimeEntry",
                column: "TaskEntryId",
                principalTable: "TaskEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntry_Project_ProjectId",
                table: "TaskEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntry_TaskEntry_TaskEntryId",
                table: "TimeEntry");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntry_TaskEntryId",
                table: "TimeEntry");

            migrationBuilder.DropIndex(
                name: "IX_TaskEntry_ProjectId",
                table: "TaskEntry");

            migrationBuilder.DropIndex(
                name: "IX_Project_CustomerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TaskEntryId",
                table: "TimeEntry");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TaskEntry");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Project");
        }
    }
}
