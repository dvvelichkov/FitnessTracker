using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Data.Migrations
{
    public partial class ChangedExerciseInProgramAndFitnessProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_FitnessPrograms_FitnessProgramId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_FitnessProgramId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ProgramDay",
                table: "FitnessPrograms");

            migrationBuilder.DropColumn(
                name: "FitnessProgramId",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExercisesInFitnessPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProgramDay",
                table: "ExercisesInFitnessPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProgramDayId",
                table: "ExercisesInFitnessPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExercisesInFitnessPrograms");

            migrationBuilder.DropColumn(
                name: "ProgramDay",
                table: "ExercisesInFitnessPrograms");

            migrationBuilder.DropColumn(
                name: "ProgramDayId",
                table: "ExercisesInFitnessPrograms");

            migrationBuilder.AddColumn<string>(
                name: "ProgramDay",
                table: "FitnessPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FitnessProgramId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_FitnessProgramId",
                table: "Exercises",
                column: "FitnessProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_FitnessPrograms_FitnessProgramId",
                table: "Exercises",
                column: "FitnessProgramId",
                principalTable: "FitnessPrograms",
                principalColumn: "Id");
        }
    }
}
