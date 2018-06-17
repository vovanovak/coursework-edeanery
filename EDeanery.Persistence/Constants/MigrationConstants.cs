namespace EDeanery.Persistence.Constants
{
    public static class MigrationConstants
    {
        public const string FacultiesTable = "Faculties";
        public const string SpecialitiesTable = "Specialities";
        public static readonly string[] FacultiesTableColumns = {"FacultyId", "Name"};
        public static readonly string[] SpecialitiesTableColumns = {"SpecialityId", "SpecialityName", "FacultyId"};
    }
}