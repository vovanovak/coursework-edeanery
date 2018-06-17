﻿using System.Collections.Generic;
using System.Linq;
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
    internal class DormitoryRoomRepository : IDormitoryRoomRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<DormitoryRoom, DormitoryRoomEntity> _dormitoryRoomMapper;
        private readonly IMapper<DormitoryRoomEntity, DormitoryRoom> _daoDormitoryRoomMapper;

        public DormitoryRoomRepository(
            IEdeaneryDbContext context,
            IMapper<DormitoryRoom, DormitoryRoomEntity> dormitoryRoomMapper,
            IMapper<DormitoryRoomEntity, DormitoryRoom> daoDormitoryRoomMapper)
        {
            _context = context;
            _dormitoryRoomMapper = dormitoryRoomMapper;
            _daoDormitoryRoomMapper = daoDormitoryRoomMapper;
        }

        private IQueryable<DormitoryRoomEntity> GetDormitoryRoomsWithStudents()
        {
            return _context.DormitoryRooms
                .Include(dr => dr.DormitoryEntity)
                .Include(dr => dr.DormitoryRoomStudents)
                .ThenInclude(dr => dr.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }

        public async Task AddAsync(DormitoryRoom entity)
        {
            var dao = _dormitoryRoomMapper.Map(entity);
            await _context.DormitoryRooms.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.DormitoryRoomId = dao.DormitoryRoomId;
        }

        public async Task DeleteAsync(int id)
        {
            var dao = await GetDormitoryRoomsWithStudents().SingleOrDefaultAsync(dr => dr.DormitoryRoomId == id);
            _context.DormitoryRooms.Remove(dao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DormitoryRoom entity)
        {
            var dao = _dormitoryRoomMapper.Map(entity);
            _context.DormitoryRooms.Update(dao);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DormitoryRoom>> GetAll()
        {
            var dormitoryRoomDaos = await GetDormitoryRoomsWithStudents().ToListAsync();
            return dormitoryRoomDaos.Select(dr => _daoDormitoryRoomMapper.Map(dr)).ToList();
        }

        public async Task<DormitoryRoom> GetById(int id)
        {
            return _daoDormitoryRoomMapper.Map(
                await GetDormitoryRoomsWithStudents().SingleOrDefaultAsync(dr => dr.DormitoryRoomId == id));
        }


        public void SetDormitoryRooms(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            var oldDormitoryRooms = _context.DormitoryRooms.Where(dr => dr.DormitoryId == dormitoryId);

            foreach (var dormitoryRoom in oldDormitoryRooms)
            {
                dormitoryRoom.DormitoryId = null;
            }

            var dormitoryRooms = _context.DormitoryRooms.Where(dr => dormitoryRoomIds.Contains(dr.DormitoryRoomId));

            foreach (var dormitoryRoom in dormitoryRooms)
            {
                dormitoryRoom.DormitoryId = dormitoryId;
            }

            _context.SaveChanges();
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId)
        {
            var dormitoryRoomsDaos = await GetDormitoryRoomsWithStudents().Where(dr => dr.DormitoryId == dormitoryId)
                .ToListAsync();
            return _daoDormitoryRoomMapper.Map(dormitoryRoomsDaos).ToList();
        }

        public async Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds)
        {
            var oldDormitoryRoomStudents =
                _context.DormitoryRoomStudents.Where(d => d.DormitoryRoomId == dormitoryRoomId);

            _context.DormitoryRoomStudents.RemoveRange(oldDormitoryRoomStudents);

            var newDormitoryRoomStudents = studentIds.Select(studentId => new DormitoryRoomStudentEntity
            {
                StudentId = studentId,
                DormitoryRoomId = dormitoryRoomId
            }).ToList();

            await _context.DormitoryRoomStudents.AddRangeAsync(newDormitoryRoomStudents);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory()
        {
            var dormitoryRooms = await GetDormitoryRoomsWithStudents().Where(r => r.DormitoryId == null).ToListAsync();
            return dormitoryRooms.Select(_daoDormitoryRoomMapper.Map).ToList();
        }

        public async Task<DormitoryRoom> GetDormitoryRoomByStudentId(int studentId)
        {
            var dormitoryRoomDao = await GetDormitoryRoomsWithStudents()
                .FirstOrDefaultAsync(dr => dr.DormitoryRoomStudents.Any(drs => drs.StudentId == studentId));

            return dormitoryRoomDao == null ? null : _daoDormitoryRoomMapper.Map(dormitoryRoomDao);
        }

        public bool IsDormitoryRoomNameUnique(string name)
        {
            return !_context.DormitoryRooms.Any(d => d.DormitoryRoomName == name);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            var freeDormitoryRooms = await GetDormitoryRoomsWithStudents()
                .Where(dr => dr.DormitoryRoomStudents.Count() < dr.MaxCountInRoom)
                .ToListAsync();

            return _daoDormitoryRoomMapper.Map(freeDormitoryRooms).ToList();
        }
    }
}