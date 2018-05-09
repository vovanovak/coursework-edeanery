namespace EDeanery.DAL.DAOs
{
    public class GroupStudent
    {
        public int GroupStudentId { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }
    }
}