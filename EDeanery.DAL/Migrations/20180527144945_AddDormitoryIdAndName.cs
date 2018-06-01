using Microsoft.EntityFrameworkCore.Migrations;

namespace EDeanery.DAL.Migrations
{
    public partial class AddDormitoryIdAndName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryEntityDormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.DropIndex(
                name: "IX_DormitoryRooms_DormitoryEntityDormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.DropColumn(
                name: "DormitoryEntityDormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.AddColumn<int>(
                name: "DormitoryId",
                table: "DormitoryRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRooms_DormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryId",
                principalTable: "Dormitories",
                principalColumn: "DormitoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.DropIndex(
                name: "IX_DormitoryRooms_DormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.DropColumn(
                name: "DormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.AddColumn<int>(
                name: "DormitoryEntityDormitoryId",
                table: "DormitoryRooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRooms_DormitoryEntityDormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryEntityDormitoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryEntityDormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryEntityDormitoryId",
                principalTable: "Dormitories",
                principalColumn: "DormitoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
