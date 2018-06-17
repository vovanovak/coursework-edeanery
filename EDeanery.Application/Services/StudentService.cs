﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;
using EDeanery.Persistence.UnitOfWork.Abstract;

namespace EDeanery.Application.Services
{
    internal class StudentService : Service<Student, int>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Student, int> Repository => UnitOfWork.StudentRepository;

        public override async Task<Student> GetById(int id)
        {
            var baseStudent = await base.GetById(id);

            baseStudent.Group = await UnitOfWork.GroupRepository.GetGroupByStudentId(id);
            baseStudent.DormitoryRoom = await UnitOfWork.DormitoryRoomRepository.GetDormitoryRoomByStudentId(id);
            
            return baseStudent;
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(
            string search,
            int? groupId, 
            int? dormitoryId,
            int? dormitoryRoomId)
        {
            return await UnitOfWork.StudentRepository.GetStudentsByFullName(search, groupId, dormitoryId, dormitoryRoomId);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search, int? groupId, int? dormitoryId, int? dormitoryRoomId)
        {
            return await UnitOfWork.StudentRepository.GetStudentsByGroup(search, groupId, dormitoryId, dormitoryRoomId);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms()
        {
            return await UnitOfWork.StudentRepository.GetStudentsWithoutRooms();
        }
    }
}