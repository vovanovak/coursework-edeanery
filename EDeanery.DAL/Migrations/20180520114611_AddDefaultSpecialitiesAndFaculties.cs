using EDeanery.DAL.Constants;
using Microsoft.EntityFrameworkCore.Migrations;
using EDeanery.DAL.DAOs;

namespace EDeanery.DAL.Migrations
{
    public partial class AddDefaultSpecialitiesAndFaculties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                MigrationConstants.FacultiesTable, 
                MigrationConstants.FacultiesTableColumns,
                new object[] {1, "FICT"});
            
            migrationBuilder.InsertData(
                MigrationConstants.FacultiesTable, 
                MigrationConstants.FacultiesTableColumns,
                new object[] {2, "IASA"});
            
            migrationBuilder.InsertData(
                MigrationConstants.FacultiesTable, 
                MigrationConstants.FacultiesTableColumns,
                new object[] {3, "FASS"});

            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {1, "Computer engineering", 1});
            
            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {2, "Software engineering", 1});
            
            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {3, "Informational systems", 1});
            
            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {4, "System Analysis", 2});
            
            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {5, "Computer Science", 2});
            
            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {6, "Metrology", 3});
            
            migrationBuilder.InsertData(
                MigrationConstants.SpecialitiesTable,
                MigrationConstants.SpecialitiesTableColumns,
                new object[] {7, "Avionic", 3});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}