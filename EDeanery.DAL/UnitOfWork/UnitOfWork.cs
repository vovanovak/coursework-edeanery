using System.Threading.Tasks;
using EDeanery.DAL.Context;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEdeaneryDbContext _edeaneryDbContext;
        
        public IDormitoryRepository DormitoryRepository { get; }
        public IDormitoryRoomRepository DormitoryRoomRepository { get; }
        public IFacultyRepository FacultyRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public ISpecialityRepository SpecialityRepository { get; }
        public IStudentRepository StudentRepository { get; }

        public UnitOfWork(
            IEdeaneryDbContext edeaneryDbContext,
            IDormitoryRepository dormitoryRepository, 
            IDormitoryRoomRepository dormitoryRoomRepository,
            IFacultyRepository facultyRepository, 
            IGroupRepository groupRepository,
            ISpecialityRepository specialityRepository, 
            IStudentRepository studentRepository)
        {
            _edeaneryDbContext = edeaneryDbContext;
            
            DormitoryRepository = dormitoryRepository;
            DormitoryRoomRepository = dormitoryRoomRepository;
            FacultyRepository = facultyRepository;
            GroupRepository = groupRepository;
            SpecialityRepository = specialityRepository;
            StudentRepository = studentRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _edeaneryDbContext.SaveChangesAsync();
        }
    }
}