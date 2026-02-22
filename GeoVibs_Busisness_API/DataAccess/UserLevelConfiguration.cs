using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVibs_Busisness_API.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserLevelConfiguration : IEntityTypeConfiguration<UserLevel>
    {
        public void Configure(EntityTypeBuilder<UserLevel> e)
        {
            e.ToTable("User_level");

            e.HasKey(x => x.Id);
            e.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            e.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();
            e.Property(x => x.VenueId).HasColumnName("venue_id");

            e.HasIndex(x => x.Name);
        }
    }
}
