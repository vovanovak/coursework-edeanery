namespace EDeanery.DAL.DAOs
{
    public class DormitoryRoomStudent
    {
        public int DormitoryRoomStudentId { get; set; }
        public int StudentId { get; set; }
        public int DormitoryRoomId { get; set; }
        public Student Student { get; set; }
        public DormitoryRoom DormitoryRoom { get; set; }
    }
}