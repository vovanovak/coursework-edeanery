namespace EDeanery.PL.Models
{
    public class StudentSelectModel : StudentGetModel
    {
        public bool Checked { get; set; }

        public StudentSelectModel(bool @checked, StudentGetModel studentGetModel) : base(studentGetModel)
        {
            Checked = @checked;
        }
    }
}