using Microsoft.EntityFrameworkCore;
using System;
using DataEntity;

namespace GeoVibs_Busisness_API.DataAccess
{
    public class VenueDbContext : DbContext
    {
        public VenueDbContext(DbContextOptions<VenueDbContext> options)
            : base(options) { }

        public DbSet<Venue> Venues => Set<Venue>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserLevel> UserLevels => Set<UserLevel>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Session> Sessions => Set<Session>();
        public DbSet<SessionDetail> SessionDetails => Set<SessionDetail>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfigurationsFromAssembly(typeof(VenueDbContext).Assembly);
        }
    }
}
