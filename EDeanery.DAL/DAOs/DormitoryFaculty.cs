namespace EDeanery.DAL.DAOs
{
    public class DormitoryFaculty
    {
        public int DormitoryFacultyId { get; set; }
        public int DormitoryId { get; set; }
        public int FacultyId { get; set; }
        public Dormitory Dormitory { get; set; }
        public Faculty Faculty { get; set; }
    }
}