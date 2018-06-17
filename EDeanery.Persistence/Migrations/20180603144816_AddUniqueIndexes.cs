using Microsoft.EntityFrameworkCore.Migrations;

namespace EDeanery.Persistence.Migrations
{
    public partial class AddUniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Specialities_FacultyId",
                table: "Specialities");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialityName",
                table: "Specialities",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dormitories",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_FacultyId_SpecialityName",
                table: "Specialities",
                columns: new[] { "FacultyId", "SpecialityName" },
                unique: true,
                filter: "[SpecialityName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupName",
                table: "Groups",
                column: "GroupName",
                unique: true,
                filter: "[GroupName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name",
                table: "Faculties",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dormitories_Name",
                table: "Dormitories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Specialities_FacultyId_SpecialityName",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupName",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_Name",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Dormitories_Name",
                table: "Dormitories");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialityName",
                table: "Specialities",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dormitories",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_FacultyId",
                table: "Specialities",
                column: "FacultyId");
        }
    }
}
