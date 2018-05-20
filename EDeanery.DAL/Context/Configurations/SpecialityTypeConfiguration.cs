using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.DAL.Context.Configurations
{
    public class SpecialityTypeConfiguration : IEntityTypeConfiguration<SpecialityEntity>
    {
        public void Configure(EntityTypeBuilder<SpecialityEntity> builder)
        {
            builder.ToTable("Specialities");
            builder.HasKey(s => s.SpecialityId);
            builder.HasOne(s => s.FacultyEntity);
        }
    }
}