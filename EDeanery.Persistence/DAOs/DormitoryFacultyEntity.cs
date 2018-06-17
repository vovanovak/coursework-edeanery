namespace EDeanery.Persistence.DAOs
{
    public class DormitoryFacultyEntity
    {
        public int DormitoryFacultyId { get; set; }
        public int DormitoryId { get; set; }
        public int FacultyId { get; set; }
        public DormitoryEntity DormitoryEntity { get; set; }
        public FacultyEntity FacultyEntity { get; set; }
    }
}