using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRTrainingTracker.Entities.Migrations
{
    //Add-Migration Migration_9_11_2021 -OutputDir Migrations -Context HRTrainingContext
    public partial class Migration_9_11_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTraining_Employees_WithTrainingEmployeeID",
                table: "EmployeeTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTraining",
                table: "EmployeeTraining");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTraining_WithTrainingEmployeeID",
                table: "EmployeeTraining");

            migrationBuilder.RenameColumn(
                name: "WithTrainingEmployeeID",
                table: "EmployeeTraining",
                newName: "EmployeesEmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingDescription",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LocalityLocalID",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrainerName",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TrainingTypesID",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BuildingID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Manager",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShiftID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTraining",
                table: "EmployeeTraining",
                columns: new[] { "EmployeesEmployeeID", "TrainingListTrainingID" });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    LocalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.LocalID);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingID);
                    table.ForeignKey(
                        name: "FK_Buildings_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_LocalityLocalID",
                table: "Trainings",
                column: "LocalityLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingTypesID",
                table: "Trainings",
                column: "TrainingTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_TrainingListTrainingID",
                table: "EmployeeTraining",
                column: "TrainingListTrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BuildingID",
                table: "Employees",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftID",
                table: "Employees",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_StateID",
                table: "Buildings",
                column: "StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Buildings_BuildingID",
                table: "Employees",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "BuildingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Shifts_ShiftID",
                table: "Employees",
                column: "ShiftID",
                principalTable: "Shifts",
                principalColumn: "ShiftID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTraining_Employees_EmployeesEmployeeID",
                table: "EmployeeTraining",
                column: "EmployeesEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Localities_LocalityLocalID",
                table: "Trainings",
                column: "LocalityLocalID",
                principalTable: "Localities",
                principalColumn: "LocalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingTypes_TrainingTypesID",
                table: "Trainings",
                column: "TrainingTypesID",
                principalTable: "TrainingTypes",
                principalColumn: "TrainingTypesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Buildings_BuildingID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Shifts_ShiftID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTraining_Employees_EmployeesEmployeeID",
                table: "EmployeeTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Localities_LocalityLocalID",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingTypes_TrainingTypesID",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_LocalityLocalID",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingTypesID",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTraining",
                table: "EmployeeTraining");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTraining_TrainingListTrainingID",
                table: "EmployeeTraining");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BuildingID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ShiftID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LocalityLocalID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainerName",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingTypesID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BuildingID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ShiftID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TransferDate",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeesEmployeeID",
                table: "EmployeeTraining",
                newName: "WithTrainingEmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingDescription",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTraining",
                table: "EmployeeTraining",
                columns: new[] { "TrainingListTrainingID", "WithTrainingEmployeeID" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_WithTrainingEmployeeID",
                table: "EmployeeTraining",
                column: "WithTrainingEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTraining_Employees_WithTrainingEmployeeID",
                table: "EmployeeTraining",
                column: "WithTrainingEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
