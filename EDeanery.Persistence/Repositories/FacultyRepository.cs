﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories
{
    internal class FacultyRepository : IFacultyRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Faculty, DAOs.FacultyEntity> _facultyMapper;
        private readonly IMapper<DAOs.FacultyEntity, Faculty> _daoFacultyMapper;

        public FacultyRepository(
            IEdeaneryDbContext context,
            IMapper<Faculty, DAOs.FacultyEntity> facultyMapper,
            IMapper<DAOs.FacultyEntity, Faculty> daoFacultyMapper)
        {
            _context = context;
            _facultyMapper = facultyMapper;
            _daoFacultyMapper = daoFacultyMapper;
        }

        public async Task AddAsync(Faculty entity)
        {
            var dao = _facultyMapper.Map(entity);
            await _context.Faculties.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.FacultyId = dao.FacultyId;
        }

        public async Task DeleteAsync(int id)
        {
            var faculty = await _context.Faculties.SingleOrDefaultAsync(d => d.FacultyId == id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Faculty entity)
        {
            var dao = _facultyMapper.Map(entity);
            _context.Faculties.Update(dao);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Faculty>> GetAll()
        {
            var facultyDaos = await _context.Faculties.ToListAsync();
            return facultyDaos.Select(d => _daoFacultyMapper.Map(d)).ToList();
        }

        public async Task<Faculty> GetById(int id)
        {
            return _daoFacultyMapper.Map(await _context.Faculties.SingleOrDefaultAsync(d => d.FacultyId == id));
        }
    }
}