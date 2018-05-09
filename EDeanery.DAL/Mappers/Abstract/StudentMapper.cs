using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class StudentMapper : IMapper<Student, DAOs.Student>, IMapper<DAOs.Student, Student>
    {
        public DAOs.Student Map(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Student Map(DAOs.Student entity)
        {
            throw new System.NotImplementedException();
        }
    }
}