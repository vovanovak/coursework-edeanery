using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.Mappers.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Repositories
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Speciality, DAOs.Speciality> _specialityMapper;
        private readonly IMapper<DAOs.Speciality, Speciality> _daoSpecialityMapper;

        public SpecialityRepository(
            IEdeaneryDbContext context,
            IMapper<Speciality, DAOs.Speciality> SpecialityMapper,
            IMapper<DAOs.Speciality, Speciality> daoSpecialityMapper)
        {
            _context = context;
            _specialityMapper = SpecialityMapper;
            _daoSpecialityMapper = daoSpecialityMapper;
        }

        public async Task AddAsync(Speciality entity)
        {
            var dao = _specialityMapper.Map(entity);
            await _context.Specialities.AddAsync(dao);
        }

        public async Task DeleteAsync(int id)
        {
            var speciality = await _context.Specialities.SingleOrDefaultAsync(d => d.SpecialityId == id);
            _context.Specialities.Remove(speciality);
        }

        public void UpdateAsync(Speciality entity)
        {
            var dao = _specialityMapper.Map(entity);
            _context.Specialities.Update(dao);
        }

        public async Task<ICollection<Speciality>> GetAll()
        {
            var specialityDaos = await _context.Specialities.ToListAsync();
            return specialityDaos.Select(d => _daoSpecialityMapper.Map(d)).ToList();
        }

        public async Task<Speciality> GetById(int id)
        {
            return _daoSpecialityMapper.Map(await _context.Specialities.SingleOrDefaultAsync(d => d.SpecialityId == id));
        }
    }
}