using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMEFRAME_api.Migrations
{
    public partial class FixOneToManyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TaskEntryId",
                table: "TimeEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TaskEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "TaskEntryId",
                table: "TimeEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TaskEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntry_Project_ProjectId",
                table: "TaskEntry",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntry_TaskEntry_TaskEntryId",
                table: "TimeEntry",
                column: "TaskEntryId",
                principalTable: "TaskEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
