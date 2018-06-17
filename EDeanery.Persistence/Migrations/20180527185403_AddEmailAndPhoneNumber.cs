using Microsoft.EntityFrameworkCore.Migrations;

namespace EDeanery.Persistence.Migrations
{
    public partial class AddEmailAndPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupStudents_GroupStudentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupStudentId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "GroupStudentId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DormitoryRoomStudentId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupStudents_GroupStudentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupStudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "GroupStudentId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DormitoryRoomStudentId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupStudentId",
                table: "Students",
                column: "GroupStudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GroupStudents_GroupStudentId",
                table: "Students",
                column: "GroupStudentId",
                principalTable: "GroupStudents",
                principalColumn: "GroupStudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
