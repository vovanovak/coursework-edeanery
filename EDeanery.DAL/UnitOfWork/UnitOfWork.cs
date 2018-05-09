using System.Threading.Tasks;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EdeaneryDbContext _edeaneryDbContext;
        
        public IDormitoryRepository DormitoryRepository { get; set; }
        public IDormitoryRoomRepository DormitoryRoomRepository { get; set; }
        public IFacultyRepository FacultyRepository { get; set; }
        public IGroupRepository GroupRepository { get; set; }
        public ISpecialityRepository SpecialityRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }

        public UnitOfWork(
            EdeaneryDbContext edeaneryDbContext,
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