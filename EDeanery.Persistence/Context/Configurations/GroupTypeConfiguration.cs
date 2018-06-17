using EDeanery.Persistence.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.Persistence.Context.Configurations
{
    internal class GroupTypeConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.GroupId);
            builder.HasIndex(b => b.GroupName).IsUnique();
            builder.HasOne(g => g.SpecialityEntity);
            builder.HasMany(g => g.GroupStudents).WithOne(g => g.GroupEntity);
        }
    }
}