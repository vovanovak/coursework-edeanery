using EDeanery.Persistence.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.Persistence.Context.Configurations
{
    internal class GroupStudentTypeConfiguration : IEntityTypeConfiguration<GroupStudentEntity>
    {
        public void Configure(EntityTypeBuilder<GroupStudentEntity> builder)
        {
            builder.ToTable("GroupStudents");
            builder.HasKey(gs => gs.GroupStudentId);
            builder.HasOne(gs => gs.GroupEntity).WithMany(g => g.GroupStudents);
            builder.HasOne(gs => gs.StudentEntity);
        }
    }
}