using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.DAL.Context.Configurations
{
    public class GroupStudentTypeConfiguration : IEntityTypeConfiguration<GroupStudentEntity>
    {
        public void Configure(EntityTypeBuilder<GroupStudentEntity> builder)
        {
            builder.ToTable("GroupStudents");
            builder.HasKey(gs => gs.GroupStudentId);
            builder.HasOne(gs => gs.GroupEntity).WithMany(g => g.GroupStudents);
            builder.HasOne(gs => gs.StudentEntity).WithOne(g => g.GroupStudentEntity);
        }
    }
}