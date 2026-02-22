using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVibs_Busisness_API.DataAccess
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> e)
        {
            e.ToTable("Item");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            e.Property(x => x.VenueId)
                .HasColumnName("venue_id")
                .IsRequired();

            e.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            e.Property(x => x.Type)
                .HasColumnName("type")
                .IsRequired();

            e.Property(x => x.Price)
                .HasColumnName("price")
                .HasPrecision(18, 2)
                .IsRequired();

            e.Property(x => x.InActive)
                .HasColumnName("in_active")
                .IsRequired();

            // Indexes
            e.HasIndex(x => new { x.VenueId, x.Name }).IsUnique();
            e.HasIndex(x => x.VenueId);
        }
    }
}
