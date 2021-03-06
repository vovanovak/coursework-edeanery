﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDeanery.Host.Providers
{
    public class ViewBagDataProvider : IViewBagDataProvider
    {
        private readonly IFacultyService _facultyService;
        private readonly ISpecialityService _specialityService;
        private readonly IMapper<Faculty, SelectListItem> _facultySelectListItemMapper;
        private readonly IMapper<Speciality, SelectListItem> _specialitySelectListItemMapper;

        public ViewBagDataProvider(
            IFacultyService facultyService,
            ISpecialityService specialityService, 
            IMapper<Faculty, SelectListItem> facultySelectListItemMapper, 
            IMapper<Speciality, SelectListItem> specialitySelectListItemMapper)
        {
            _facultyService = facultyService;
            _specialityService = specialityService;
            _facultySelectListItemMapper = facultySelectListItemMapper;
            _specialitySelectListItemMapper = specialitySelectListItemMapper;
        }

        public async Task InitFaculties(dynamic viewBag)
        {
            var faculties = await _facultyService.GetAll();
            viewBag.Faculties = _facultySelectListItemMapper.Map(faculties).ToList();
        }

        public async Task InitSpecialities(dynamic viewBag, int facultyId)
        {
            var specialities = await _specialityService.GetByFacultyId(facultyId);
            viewBag.Specialities = _specialitySelectListItemMapper.Map(specialities).ToList();
        }

        public async Task InitFacultiesAndSpecialities(dynamic viewBag)
        {
            await InitFaculties(viewBag);

            var faculties = (List<SelectListItem>) viewBag.Faculties;
            int facultyId = int.Parse(faculties.First().Value);
            
            await InitSpecialities(viewBag, facultyId);
        }
    }
}