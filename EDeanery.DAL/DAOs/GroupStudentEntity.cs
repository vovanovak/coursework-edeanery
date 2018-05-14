namespace EDeanery.DAL.DAOs
{
    public class GroupStudentEntity
    {
        public int GroupStudentId { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public GroupEntity GroupEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }
    }
}