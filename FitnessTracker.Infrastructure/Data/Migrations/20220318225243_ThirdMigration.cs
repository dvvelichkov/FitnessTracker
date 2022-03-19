using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessTracker.Infrastructure.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPrograms_AspNetUsers_UserId1",
                table: "FitnessPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalRecords_AspNetUsers_UserId1",
                table: "PersonalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplementationPlans_AspNetUsers_UserId1",
                table: "SupplementationPlans");

            migrationBuilder.DropIndex(
                name: "IX_SupplementationPlans_UserId1",
                table: "SupplementationPlans");

            migrationBuilder.DropIndex(
                name: "IX_PersonalRecords_UserId1",
                table: "PersonalRecords");

            migrationBuilder.DropIndex(
                name: "IX_FitnessPrograms_UserId1",
                table: "FitnessPrograms");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "SupplementationPlans");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PersonalRecords");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "FitnessPrograms");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "SupplementationPlans",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PersonalRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "FitnessPrograms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplementationPlans_UserId1",
                table: "SupplementationPlans",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRecords_UserId1",
                table: "PersonalRecords",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPrograms_UserId1",
                table: "FitnessPrograms",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPrograms_AspNetUsers_UserId1",
                table: "FitnessPrograms",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalRecords_AspNetUsers_UserId1",
                table: "PersonalRecords",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplementationPlans_AspNetUsers_UserId1",
                table: "SupplementationPlans",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
