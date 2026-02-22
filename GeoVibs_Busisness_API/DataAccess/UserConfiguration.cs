using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVibs_Busisness_API.DataAccess
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> e)
        {
            e.ToTable("User");

            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
            e.Property(x => x.VenueId).HasColumnName("venue_id").IsRequired();
            e.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            e.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(30).IsRequired();
            e.Property(x => x.PasswordHash).HasColumnName("password_hash").IsRequired();
            e.Property(x => x.Email).HasColumnName("email").HasMaxLength(150);
            e.Property(x => x.UserLevelId).HasColumnName("user_level_id");
            e.Property(x => x.InActive).HasColumnName("in_active");
            e.Property(x => x.CreatedAt).HasColumnName("created_at");

            e.HasIndex(x => new { x.VenueId, x.Email }).IsUnique();

            e.HasOne<UserLevel>()
                .WithMany()
                .HasForeignKey(x => x.UserLevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
