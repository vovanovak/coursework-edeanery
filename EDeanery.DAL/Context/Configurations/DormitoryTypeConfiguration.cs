using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.DAL.Context.Configurations
{
    internal class DormitoryTypeConfiguration : IEntityTypeConfiguration<DormitoryEntity>
    {
        public void Configure(EntityTypeBuilder<DormitoryEntity> builder)
        {
            builder.ToTable("Dormitories");
            builder.HasKey(d => d.DormitoryId);
            builder.HasIndex(d => d.Name).IsUnique();
            builder.HasMany(d => d.DormitoryFaculties);
            builder.HasMany(d => d.DormitoryRooms).WithOne(dr => dr.DormitoryEntity).HasForeignKey(dr => dr.DormitoryId);
        }
    }
}