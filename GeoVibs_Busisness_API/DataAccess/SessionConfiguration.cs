using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVibs_Busisness_API.DataAccess
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> e)
        {
            e.ToTable("Session");

            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            e.Property(x => x.VenueId).HasColumnName("venue_id");
            e.Property(x => x.RoomId).HasColumnName("room_id");
            e.Property(x => x.MovieId).HasColumnName("movie_id");

            e.Property(x => x.StartAt).HasColumnName("start_at");
            e.Property(x => x.ExpectedEndAt).HasColumnName("expected_end_at");
            e.Property(x => x.EndAt).HasColumnName("end_at");

            e.Property(x => x.RoomCharge).HasColumnName("room_charge").HasPrecision(18, 2);
            e.Property(x => x.ExtraCharge).HasColumnName("extra_charge").HasPrecision(18, 2);
            e.Property(x => x.Total).HasColumnName("total").HasPrecision(18, 2);

            e.Property(x => x.Status).HasColumnName("status");
            e.Property(x => x.CreatedBy).HasColumnName("created_by");
            e.Property(x => x.CreatedAt).HasColumnName("created_at");

            e.HasIndex(x => new { x.VenueId, x.Status });

            e.HasOne<Room>()
                .WithMany()
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
