using Microsoft.EntityFrameworkCore.Migrations;

namespace HRTrainingTracker.Entities.Migrations
{
    //Add-Migration Migration_9_17_2021_2 -OutputDir Migrations -Context HRTrainingContext
    public partial class Migration_9_17_2021_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Expired",
                table: "Trainings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "Trainings");
        }
    }
}
