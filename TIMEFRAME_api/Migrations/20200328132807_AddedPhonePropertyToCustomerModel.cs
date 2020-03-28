using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMEFRAME_api.Migrations
{
    public partial class AddedPhonePropertyToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customer");
        }
    }
}
