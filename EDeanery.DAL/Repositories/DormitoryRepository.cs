﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.DAOs;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.Mappers.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Repositories
{
    internal class DormitoryRepository : IDormitoryRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Dormitory, DAOs.DormitoryEntity> _dormitoryMapper;
        private readonly IMapper<DAOs.DormitoryEntity, Dormitory> _daoDormitoryMapper;

        public DormitoryRepository(
            IEdeaneryDbContext context,
            IMapper<Dormitory, DAOs.DormitoryEntity> dormitoryMapper,
            IMapper<DAOs.DormitoryEntity, Dormitory> daoDormitoryMapper)
        {
            _context = context;
            _dormitoryMapper = dormitoryMapper;
            _daoDormitoryMapper = daoDormitoryMapper;
        }

        private IQueryable<DormitoryEntity> GetDormitoriesWithIncludes()
        {
            return _context.Dormitories
                .Include(d => d.DormitoryFaculties)
                .ThenInclude(df => df.FacultyEntity)
                .Include(d => d.DormitoryRooms)
                .ThenInclude(d => d.DormitoryRoomStudents)
                .ThenInclude(drs => drs.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }

        public async Task AddAsync(Dormitory entity)
        {
            var dao = _dormitoryMapper.Map(entity);
            await _context.Dormitories.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.DormitoryId = dao.DormitoryId;
        }

        public async Task DeleteAsync(int id)
        {
            var dormitory = await _context.Dormitories.SingleOrDefaultAsync(d => d.DormitoryId == id);
            _context.Dormitories.Remove(dormitory);
        }

        public void UpdateAsync(Dormitory entity)
        {
            var dao = _dormitoryMapper.Map(entity);
            _context.Dormitories.Update(dao);
        }

        public async Task<ICollection<Dormitory>> GetAll()
        {
            var dormitoryDaos = await GetDormitoriesWithIncludes().ToListAsync();
            return dormitoryDaos.Select(d => _daoDormitoryMapper.Map(d)).ToList();
        }

        public async Task<Dormitory> GetById(int id)
        {
            var dormitoryEntity = await GetDormitoriesWithIncludes().SingleOrDefaultAsync(d => d.DormitoryId == id);
            return _daoDormitoryMapper.Map(dormitoryEntity);
        }
    }
}