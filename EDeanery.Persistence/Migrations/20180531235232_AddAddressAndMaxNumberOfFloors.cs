using Microsoft.EntityFrameworkCore.Migrations;

namespace EDeanery.Persistence.Migrations
{
    public partial class AddAddressAndMaxNumberOfFloors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupStudents_GroupStudentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupStudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupStudentId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Dormitories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFlors",
                table: "Dormitories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudents_StudentId",
                table: "GroupStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_Students_StudentId",
                table: "GroupStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_Students_StudentId",
                table: "GroupStudents");

            migrationBuilder.DropIndex(
                name: "IX_GroupStudents_StudentId",
                table: "GroupStudents");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Dormitories");

            migrationBuilder.DropColumn(
                name: "NumberOfFlors",
                table: "Dormitories");

            migrationBuilder.AddColumn<int>(
                name: "GroupStudentId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupStudentId",
                table: "Students",
                column: "GroupStudentId",
                unique: true,
                filter: "[GroupStudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GroupStudents_GroupStudentId",
                table: "Students",
                column: "GroupStudentId",
                principalTable: "GroupStudents",
                principalColumn: "GroupStudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
