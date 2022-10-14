using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedCompletedWorkoutstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedWorkouts",
                columns: table => new
                {
                    CompletedWorkoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedWorkouts", x => x.CompletedWorkoutId);
                    table.ForeignKey(
                        name: "FK_CompletedWorkouts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_CompletedWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkouts_ProfileId",
                table: "CompletedWorkouts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkouts_WorkoutId",
                table: "CompletedWorkouts",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedWorkouts");
        }
    }
}
