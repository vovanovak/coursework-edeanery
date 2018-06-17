using EDeanery.Persistence.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.Persistence.Context.Configurations
{
    internal class SpecialityTypeConfiguration : IEntityTypeConfiguration<SpecialityEntity>
    {
        public void Configure(EntityTypeBuilder<SpecialityEntity> builder)
        {
            builder.ToTable("Specialities");
            builder.HasKey(s => s.SpecialityId);
            builder.HasIndex(s => new { s.FacultyId, s.SpecialityName }).IsUnique();
            builder.HasOne(s => s.FacultyEntity);
        }
    }
}