using Microsoft.EntityFrameworkCore.Migrations;

namespace EDeanery.DAL.Migrations
{
    public partial class AddFacultyIdAndSpecialityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE [dbo].[Students] DROP COLUMN [SpecialityName]
                GO
                ALTER TABLE [dbo].[Students] DROP COLUMN [FacultyName]
                GO
                
                ALTER TABLE [dbo].[Students] ADD [SpecialityId] int
                GO
                
                ALTER TABLE [dbo].[Students] ADD CONSTRAINT [FK_Students_Specialities_SpecialityId]
                FOREIGN KEY [SpecialityId] REFERENCES [dbo].[Specialities]([SpecialityId])
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
