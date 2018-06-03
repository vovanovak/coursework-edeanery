using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.DAL.Context.Configurations
{
    internal class FacultyTypeConfiguration : IEntityTypeConfiguration<FacultyEntity>
    {
        public void Configure(EntityTypeBuilder<FacultyEntity> builder)
        {
            builder.ToTable("Faculties");
            builder.HasKey(f => f.FacultyId);
            builder.HasIndex(f => f.Name).IsUnique();
            builder.HasMany(f => f.DormitoryFaculties).WithOne(df => df.FacultyEntity);
        }
    }
}