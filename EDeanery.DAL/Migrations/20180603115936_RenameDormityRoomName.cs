using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EDeanery.DAL.Migrations
{
    public partial class RenameDormityRoomName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DormityRoomName",
                table: "DormitoryRooms",
                newName: "DormitoryRoomName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DormitoryRoomName",
                table: "DormitoryRooms",
                newName: "DormityRoomName");
        }
    }
}
