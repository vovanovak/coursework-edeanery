namespace EDeanery.BLL.Domain.ValueObjects
{
    public struct StudentTickerInfo
    {
        public string StudentTickerId { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }

        public StudentTickerInfo(
            string studentTickerId,
            string facultyName,
            string specialityName, 
            int course,
            bool onBudget)
        {
            StudentTickerId = studentTickerId;
            FacultyName = facultyName;
            SpecialityName = specialityName;
            Course = course;
            OnBudget = onBudget;
        }
    }
}