using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using DormitoryRoom = EDeanery.Domain.Entities.DormitoryRoom;

namespace EDeanery.Persistence.Repositories
{
    internal class DormitoryRoomRepository : Repository<DormitoryRoom, DormitoryRoomEntity, int>, IDormitoryRoomRepository
    {
        public DormitoryRoomRepository(
            IEdeaneryDbContext context,
            IMapper<DormitoryRoom, DormitoryRoomEntity> dormitoryRoomMapper,
            IMapper<DormitoryRoomEntity, DormitoryRoom> daoDormitoryRoomMapper)
            : base(context, dormitoryRoomMapper, daoDormitoryRoomMapper)
        {
        }

        protected override DbSet<DormitoryRoomEntity> Table => Context.DormitoryRooms;
        protected override IQueryable<DormitoryRoomEntity> GetWithAllIncludes()
        {
            return Context.DormitoryRooms
                .Include(dr => dr.DormitoryEntity)
                .Include(dr => dr.DormitoryRoomStudents)
                .ThenInclude(dr => dr.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }

        protected override Expression<Func<DormitoryRoomEntity, bool>> GetDaoById(int id)
        {
            return dormitoryRoom => dormitoryRoom.DormitoryRoomId == id;
        }

        protected override void SetId(DormitoryRoom entity, DormitoryRoomEntity dao)
        {
            entity.DormitoryRoomId = dao.DormitoryRoomId;
        }

        public void SetDormitoryRooms(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            var oldDormitoryRooms = Context.DormitoryRooms.Where(dr => dr.DormitoryId == dormitoryId);

            foreach (var dormitoryRoom in oldDormitoryRooms)
            {
                dormitoryRoom.DormitoryId = null;
            }

            var dormitoryRooms = Context.DormitoryRooms.Where(dr => dormitoryRoomIds.Contains(dr.DormitoryRoomId));

            foreach (var dormitoryRoom in dormitoryRooms)
            {
                dormitoryRoom.DormitoryId = dormitoryId;
            }

            Context.SaveChanges();
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId)
        {
            var dormitoryRoomsDaos = await GetWithAllIncludes().Where(dr => dr.DormitoryId == dormitoryId)
                .ToListAsync();
            return EntityMapper.Map(dormitoryRoomsDaos).ToList();
        }

        public async Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds)
        {
            var oldDormitoryRoomStudents =
                Context.DormitoryRoomStudents.Where(d => d.DormitoryRoomId == dormitoryRoomId);

            Context.DormitoryRoomStudents.RemoveRange(oldDormitoryRoomStudents);

            var newDormitoryRoomStudents = studentIds.Select(studentId => new DormitoryRoomStudentEntity
            {
                StudentId = studentId,
                DormitoryRoomId = dormitoryRoomId
            }).ToList();

            await Context.DormitoryRoomStudents.AddRangeAsync(newDormitoryRoomStudents);
            await Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory()
        {
            var dormitoryRooms = await GetWithAllIncludes().Where(r => r.DormitoryId == null).ToListAsync();
            return dormitoryRooms.Select(EntityMapper.Map).ToList();
        }

        public async Task<DormitoryRoom> GetDormitoryRoomByStudentId(int studentId)
        {
            var dormitoryRoomDao = await GetWithAllIncludes()
                .FirstOrDefaultAsync(dr => dr.DormitoryRoomStudents.Any(drs => drs.StudentId == studentId));

            return dormitoryRoomDao == null ? null : EntityMapper.Map(dormitoryRoomDao);
        }

        public bool IsDormitoryRoomNameUnique(string name)
        {
            return !Context.DormitoryRooms.Any(d => d.DormitoryRoomName == name);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            var freeDormitoryRooms = await GetWithAllIncludes()
                .Where(dr => dr.DormitoryRoomStudents.Count() < dr.MaxCountInRoom)
                .ToListAsync();

            return EntityMapper.Map(freeDormitoryRooms).ToList();
        }
    }
}