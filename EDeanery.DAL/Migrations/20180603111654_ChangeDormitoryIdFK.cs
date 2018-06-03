using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EDeanery.DAL.Migrations
{
    public partial class ChangeDormitoryIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.DropIndex(
                name: "IX_DormitoryRoomStudents_StudentId",
                table: "DormitoryRoomStudents");

            migrationBuilder.DropColumn(
                name: "DormitoryRoomStudentId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "DormitoryId",
                table: "DormitoryRooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRoomStudents_StudentId",
                table: "DormitoryRoomStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryId",
                principalTable: "Dormitories",
                principalColumn: "DormitoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryId",
                table: "DormitoryRooms");

            migrationBuilder.DropIndex(
                name: "IX_DormitoryRoomStudents_StudentId",
                table: "DormitoryRoomStudents");

            migrationBuilder.AddColumn<int>(
                name: "DormitoryRoomStudentId",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DormitoryId",
                table: "DormitoryRooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRoomStudents_StudentId",
                table: "DormitoryRoomStudents",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DormitoryRooms_Dormitories_DormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryId",
                principalTable: "Dormitories",
                principalColumn: "DormitoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
