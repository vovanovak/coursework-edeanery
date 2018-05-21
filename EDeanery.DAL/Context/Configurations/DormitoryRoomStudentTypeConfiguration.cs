using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.DAL.Context.Configurations
{
    internal class DormitoryRoomStudentTypeConfiguration : IEntityTypeConfiguration<DormitoryRoomStudentEntity>
    {
        public void Configure(EntityTypeBuilder<DormitoryRoomStudentEntity> builder)
        {
            builder.ToTable("DormitoryRoomStudents");
            builder.HasKey(drs => drs.DormitoryRoomStudentId);
            builder.HasOne(drs => drs.DormitoryRoomEntity)
                .WithMany(dr => dr.DormitoryRoomStudents);
            builder.HasOne(drs => drs.StudentEntity)
                .WithOne(s => s.DormitoryRoomStudentEntity);
        }
    }
}