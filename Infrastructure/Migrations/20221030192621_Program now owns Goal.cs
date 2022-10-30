using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ProgramnowownsGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Programs_ProgramId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ProgramId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Goals");

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "Programs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_GoalId",
                table: "Programs",
                column: "GoalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Goals_GoalId",
                table: "Programs",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Goals_GoalId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_GoalId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Programs");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Goals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ProgramId",
                table: "Goals",
                column: "ProgramId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Programs_ProgramId",
                table: "Goals",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
