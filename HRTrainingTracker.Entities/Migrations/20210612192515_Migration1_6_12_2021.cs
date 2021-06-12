using Microsoft.EntityFrameworkCore.Migrations;

namespace HRTrainingTracker.Entities.Migrations
{
    public partial class Migration1_6_12_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTraining",
                columns: table => new
                {
                    TrainingListTrainingID = table.Column<int>(type: "int", nullable: false),
                    WithTrainingEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTraining", x => new { x.TrainingListTrainingID, x.WithTrainingEmployeeID });
                    table.ForeignKey(
                        name: "FK_EmployeeTraining_Employees_WithTrainingEmployeeID",
                        column: x => x.WithTrainingEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTraining_Trainings_TrainingListTrainingID",
                        column: x => x.TrainingListTrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_WithTrainingEmployeeID",
                table: "EmployeeTraining",
                column: "WithTrainingEmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTraining");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
