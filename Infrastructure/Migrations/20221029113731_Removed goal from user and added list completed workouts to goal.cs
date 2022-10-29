using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Removedgoalfromuserandaddedlistcompletedworkoutstogoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedWorkouts_Profiles_ProfileId",
                table: "CompletedWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_UserId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_CompletedWorkouts_ProfileId",
                table: "CompletedWorkouts");

            migrationBuilder.DropColumn(
                name: "IsAchieved",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "CompletedWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "CompletedWorkouts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkouts_GoalId",
                table: "CompletedWorkouts",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedWorkouts_Goals_GoalId",
                table: "CompletedWorkouts",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedWorkouts_Goals_GoalId",
                table: "CompletedWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_CompletedWorkouts_GoalId",
                table: "CompletedWorkouts");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "CompletedWorkouts");

            migrationBuilder.AddColumn<bool>(
                name: "IsAchieved",
                table: "Goals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Goals",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "CompletedWorkouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkouts_ProfileId",
                table: "CompletedWorkouts",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedWorkouts_Profiles_ProfileId",
                table: "CompletedWorkouts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
