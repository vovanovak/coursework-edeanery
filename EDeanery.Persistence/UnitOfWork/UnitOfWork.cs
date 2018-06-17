using System.Threading.Tasks;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.Repositories.Abstract;
using EDeanery.Persistence.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EDeanery.Persistence.UnitOfWork
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

        public Task<IDbContextTransaction> BeginTransaction()
        {
            return (_edeaneryDbContext as DbContext).Database.BeginTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _edeaneryDbContext.SaveChangesAsync();
        }
    }
}