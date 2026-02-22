using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVibs_Busisness_API.DataAccess
{
    public class SessionDetailConfiguration : IEntityTypeConfiguration<SessionDetail>
    {
        public void Configure(EntityTypeBuilder<SessionDetail> e)
        {
            e.ToTable("Session_Detail");

            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
            e.Property(x => x.VenueId).HasColumnName("venue_id");
            e.Property(x => x.SessionId).HasColumnName("session_id");
            e.Property(x => x.ItemId).HasColumnName("item_id");

            e.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            e.Property(x => x.UnitPrice).HasColumnName("unit_price").HasPrecision(18, 2);
            e.Property(x => x.Qty).HasColumnName("qty");
            e.Property(x => x.Total).HasColumnName("total").HasPrecision(18, 2);
            e.Property(x => x.CreatedAt).HasColumnName("created_at");

            e.HasIndex(x => new { x.VenueId, x.SessionId });
            e.HasIndex(x => x.SessionId);

            e.HasOne<Session>()
                .WithMany()
                .HasForeignKey(x => x.SessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
