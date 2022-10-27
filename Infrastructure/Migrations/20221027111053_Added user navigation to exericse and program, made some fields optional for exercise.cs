using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Addedusernavigationtoexericseandprogrammadesomefieldsoptionalforexercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributorUserId",
                table: "Programs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Seconds",
                table: "Exercises",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Repetitions",
                table: "Exercises",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "DistanceInKm",
                table: "Exercises",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "ContributorUserId",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ContributorUserId",
                table: "Programs",
                column: "ContributorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ContributorUserId",
                table: "Exercises",
                column: "ContributorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_ContributorUserId",
                table: "Exercises",
                column: "ContributorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Users_ContributorUserId",
                table: "Programs",
                column: "ContributorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_ContributorUserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Users_ContributorUserId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ContributorUserId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ContributorUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ContributorUserId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ContributorUserId",
                table: "Exercises");

            migrationBuilder.AlterColumn<double>(
                name: "Seconds",
                table: "Exercises",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Repetitions",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DistanceInKm",
                table: "Exercises",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
