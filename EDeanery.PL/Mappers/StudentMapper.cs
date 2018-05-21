using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Models;

namespace EDeanery.PL.Mappers
{
    public class StudentMapper : IMapper<Student, StudentGetModel>, IMapper<StudentPostModel, Student>
    {
        public StudentGetModel Map(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Student Map(StudentPostModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}