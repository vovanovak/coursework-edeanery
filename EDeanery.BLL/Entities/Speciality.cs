namespace EDeanery.BLL.Entities
{
    public class Speciality
    {
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public Faculty Faculty { get; set; }
    }
}