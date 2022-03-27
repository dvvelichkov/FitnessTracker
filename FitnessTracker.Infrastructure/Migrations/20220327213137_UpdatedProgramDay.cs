using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    public partial class UpdatedProgramDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ProgramDays_ProgramDayId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInFitnessPrograms_Exercises_ExerciseId",
                table: "ExercisesInFitnessPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInFitnessPrograms_ProgramDays_ProgramDayId",
                table: "ExercisesInFitnessPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ProgramDayId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisesInFitnessPrograms",
                table: "ExercisesInFitnessPrograms");

            migrationBuilder.DropColumn(
                name: "ProgramDayId",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "ExercisesInFitnessPrograms",
                newName: "ExerciseInProgramDay");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisesInFitnessPrograms_ProgramDayId",
                table: "ExerciseInProgramDay",
                newName: "IX_ExerciseInProgramDay_ProgramDayId");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "ProgramDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseInProgramDay",
                table: "ExerciseInProgramDay",
                columns: new[] { "ExerciseId", "ProgramDayId" });

            migrationBuilder.CreateTable(
                name: "ExerciseProgramDay",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    ProgramDaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseProgramDay", x => new { x.ExercisesId, x.ProgramDaysId });
                    table.ForeignKey(
                        name: "FK_ExerciseProgramDay_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseProgramDay_ProgramDays_ProgramDaysId",
                        column: x => x.ProgramDaysId,
                        principalTable: "ProgramDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProgramDay_ProgramDaysId",
                table: "ExerciseProgramDay",
                column: "ProgramDaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInProgramDay_Exercises_ExerciseId",
                table: "ExerciseInProgramDay",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInProgramDay_ProgramDays_ProgramDayId",
                table: "ExerciseInProgramDay",
                column: "ProgramDayId",
                principalTable: "ProgramDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInProgramDay_Exercises_ExerciseId",
                table: "ExerciseInProgramDay");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInProgramDay_ProgramDays_ProgramDayId",
                table: "ExerciseInProgramDay");

            migrationBuilder.DropTable(
                name: "ExerciseProgramDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseInProgramDay",
                table: "ExerciseInProgramDay");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ProgramDays");

            migrationBuilder.RenameTable(
                name: "ExerciseInProgramDay",
                newName: "ExercisesInFitnessPrograms");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseInProgramDay_ProgramDayId",
                table: "ExercisesInFitnessPrograms",
                newName: "IX_ExercisesInFitnessPrograms_ProgramDayId");

            migrationBuilder.AddColumn<int>(
                name: "ProgramDayId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercisesInFitnessPrograms",
                table: "ExercisesInFitnessPrograms",
                columns: new[] { "ExerciseId", "ProgramDayId" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ProgramDayId",
                table: "Exercises",
                column: "ProgramDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ProgramDays_ProgramDayId",
                table: "Exercises",
                column: "ProgramDayId",
                principalTable: "ProgramDays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInFitnessPrograms_Exercises_ExerciseId",
                table: "ExercisesInFitnessPrograms",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInFitnessPrograms_ProgramDays_ProgramDayId",
                table: "ExercisesInFitnessPrograms",
                column: "ProgramDayId",
                principalTable: "ProgramDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
