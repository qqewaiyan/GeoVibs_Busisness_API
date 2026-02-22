using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVibs_Busisness_API.DataAccess
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> e)
        {
            e.ToTable("Room");

            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            e.Property(x => x.VenueId).HasColumnName("venue_id");
            e.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            e.Property(x => x.Feature).HasColumnName("feature").HasMaxLength(150);
            e.Property(x => x.BaseHourlyRate).HasColumnName("base_rate").HasPrecision(18, 2);
            e.Property(x => x.Status).HasColumnName("status");
            e.Property(x => x.CreatedAt).HasColumnName("created_at");
            e.Property(x => x.InActive).HasColumnName("in_active");
            e.HasIndex(x => new { x.VenueId, x.Status });
        }
    }
}
