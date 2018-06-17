using EDeanery.Persistence.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.Persistence.Context.Configurations
{
    internal class DormitoryFacultyTypeConfiguration : IEntityTypeConfiguration<DormitoryFacultyEntity>
    {
        public void Configure(EntityTypeBuilder<DormitoryFacultyEntity> builder)
        {
            builder.ToTable("DormitoryFaculties");
            builder.HasKey(df => df.DormitoryFacultyId);
            builder.HasOne(df => df.DormitoryEntity)
                .WithMany(d => d.DormitoryFaculties);
            builder.HasOne(df => df.FacultyEntity)
                .WithMany(d => d.DormitoryFaculties);
        }
    }
}