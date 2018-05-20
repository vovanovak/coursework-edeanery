namespace EDeanery.BLL.Domain.ValueObjects
{
    public class StudentTicketInfo
    {
        public string StudentTicketId { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }

        public StudentTicketInfo(
            string studentTicketId,
            string facultyName,
            string specialityName, 
            int course,
            bool onBudget)
        {
            StudentTicketId = studentTicketId;
            FacultyName = facultyName;
            SpecialityName = specialityName;
            Course = course;
            OnBudget = onBudget;
        }
    }
}