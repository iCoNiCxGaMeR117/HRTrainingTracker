using Microsoft.EntityFrameworkCore.Migrations;

namespace HRTrainingTracker.Entities.Migrations
{
    //Add-Migration Migration_9_17_2021 -OutputDir Migrations -Context HRTrainingContext
    public partial class Migration_9_17_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingTypeName",
                table: "TrainingTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingTypeName",
                table: "TrainingTypes");
        }
    }
}
