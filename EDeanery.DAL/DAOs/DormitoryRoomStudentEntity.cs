namespace EDeanery.DAL.DAOs
{
    public class DormitoryRoomStudentEntity
    {
        public int DormitoryRoomStudentId { get; set; }
        public int StudentId { get; set; }
        public int DormitoryRoomId { get; set; }
        public StudentEntity StudentEntity { get; set; }
        public DormitoryRoomEntity DormitoryRoomEntity { get; set; }
    }
}