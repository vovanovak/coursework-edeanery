namespace EDeanery.DAL.DAOs
{
    public class DormitoryRoomStudent
    {
        public int DormitoryRoomStudentId { get; set; }
        public Student Student { get; set; }
        public Dormitory Dormitory { get; set; }
    }
}