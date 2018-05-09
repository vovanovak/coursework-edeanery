namespace EDeanery.DAL.DAOs
{
    public class Speciality
    {
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public Faculty Faculty { get; set; }
    }
}