using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Constrainedseveral1t1relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_UserId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Workouts",
                newName: "ContributorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                newName: "IX_Workouts_ContributorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_ContributorUserId",
                table: "Workouts",
                column: "ContributorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_ContributorUserId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "ContributorUserId",
                table: "Workouts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_ContributorUserId",
                table: "Workouts",
                newName: "IX_Workouts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_UserId",
                table: "Workouts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
