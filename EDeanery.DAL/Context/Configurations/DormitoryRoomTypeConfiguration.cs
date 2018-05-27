using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDeanery.DAL.Context.Configurations
{
    internal class DormitoryRoomTypeConfiguration : IEntityTypeConfiguration<DormitoryRoomEntity>
    {
        public void Configure(EntityTypeBuilder<DormitoryRoomEntity> builder)
        {
            builder.ToTable("DormitoryRooms");
            builder.HasKey(dr => dr.DormitoryRoomId);
            builder.HasOne(dr => dr.DormitoryEntity).WithMany(d => d.DormitoryRooms).HasForeignKey(k => k.DormitoryId);
            builder.HasMany(dr => dr.DormitoryRoomStudents);
        }
    }
}