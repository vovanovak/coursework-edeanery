using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EDeanery.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dormitories",
                columns: table => new
                {
                    DormitoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxCountOfMembers = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dormitories", x => x.DormitoryId);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryRooms",
                columns: table => new
                {
                    DormitoryRoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryEntityDormitoryId = table.Column<int>(nullable: true),
                    DormityRoomName = table.Column<string>(nullable: true),
                    MaxCountInRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryRooms", x => x.DormitoryRoomId);
                    table.ForeignKey(
                        name: "FK_DormitoryRooms_Dormitories_DormitoryEntityDormitoryId",
                        column: x => x.DormitoryEntityDormitoryId,
                        principalTable: "Dormitories",
                        principalColumn: "DormitoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryFaculties",
                columns: table => new
                {
                    DormitoryFacultyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryId = table.Column<int>(nullable: false),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryFaculties", x => x.DormitoryFacultyId);
                    table.ForeignKey(
                        name: "FK_DormitoryFaculties_Dormitories_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitories",
                        principalColumn: "DormitoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryFaculties_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    SpecialityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(nullable: false),
                    SpecialityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.SpecialityId);
                    table.ForeignKey(
                        name: "FK_Specialities_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudents",
                columns: table => new
                {
                    GroupStudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudents", x => x.GroupStudentId);
                    table.ForeignKey(
                        name: "FK_GroupStudents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Course = table.Column<int>(nullable: false),
                    DormitoryRoomStudentId = table.Column<int>(nullable: false),
                    FacultyName = table.Column<string>(nullable: true),
                    FathersName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GroupStudentId = table.Column<int>(nullable: false),
                    IdentificationCode = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OnBudget = table.Column<bool>(nullable: false),
                    PassportIdentifier = table.Column<string>(nullable: true),
                    SpecialityName = table.Column<string>(nullable: true),
                    StartOfLearning = table.Column<DateTime>(nullable: false),
                    StudentTicketId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_GroupStudents_GroupStudentId",
                        column: x => x.GroupStudentId,
                        principalTable: "GroupStudents",
                        principalColumn: "GroupStudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryRoomStudents",
                columns: table => new
                {
                    DormitoryRoomStudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryRoomId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryRoomStudents", x => x.DormitoryRoomStudentId);
                    table.ForeignKey(
                        name: "FK_DormitoryRoomStudents_DormitoryRooms_DormitoryRoomId",
                        column: x => x.DormitoryRoomId,
                        principalTable: "DormitoryRooms",
                        principalColumn: "DormitoryRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryRoomStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryFaculties_DormitoryId",
                table: "DormitoryFaculties",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryFaculties_FacultyId",
                table: "DormitoryFaculties",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRooms_DormitoryEntityDormitoryId",
                table: "DormitoryRooms",
                column: "DormitoryEntityDormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRoomStudents_DormitoryRoomId",
                table: "DormitoryRoomStudents",
                column: "DormitoryRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryRoomStudents_StudentId",
                table: "DormitoryRoomStudents",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialityId",
                table: "Groups",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudents_GroupId",
                table: "GroupStudents",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_FacultyId",
                table: "Specialities",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupStudentId",
                table: "Students",
                column: "GroupStudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DormitoryFaculties");

            migrationBuilder.DropTable(
                name: "DormitoryRoomStudents");

            migrationBuilder.DropTable(
                name: "DormitoryRooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Dormitories");

            migrationBuilder.DropTable(
                name: "GroupStudents");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
