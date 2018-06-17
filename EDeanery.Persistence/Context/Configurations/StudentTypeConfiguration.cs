using EDeanery.Persistence.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.Persistence.Context.Configurations
{
    internal class StudentTypeConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.StudentId);
            builder.HasOne(s => s.SpecialityEntity).WithMany(s => s.Students).HasForeignKey(s => s.SpecialityId);
        }
    }
}