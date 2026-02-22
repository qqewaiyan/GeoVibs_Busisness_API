namespace GeoVibs_Busisness_API.Service.Venue
{
    using GeoVibs_Busisness_API.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using DataEntity;

    public class VenueService : IVenueService
    {
        private readonly VenueDbContext _db;

        public VenueService(VenueDbContext db)
        {
            _db = db;
        }

        public async Task<List<Venue>> GetAllAsync()
        {
            return await _db.Venues
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<Venue?> GetByIdAsync(int id)
        {
            return await _db.Venues.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task<bool> SaveAsync(Venue venue)
        {
            var existingVenue = await GetByIdAsync(venue.Id);
            if(existingVenue is not null)
            {
                _db.Venues.Update(venue);
            }
            else
            {
                venue.CreatedAt = DateTime.UtcNow; 
                _db.Venues.Add(venue);
            }
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingVenue = await GetByIdAsync(id);
            if(existingVenue is not null)
            {
                _db.Venues.Remove(existingVenue);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Venue?> GetByPhoneNumberAsync(string ph)
        {
            var existingVenue = await _db.Venues.FirstOrDefaultAsync(x=> x.Phone == ph);
            if(existingVenue is not null )
            {
                return existingVenue;
            }
            return null;
        }

        public async Task<Venue?> GetByIdWithNoTrackingAsync(int id)
        {
            return await _db.Venues.AsNoTracking().FirstOrDefaultAsync(X => X.Id == id);
        }
    }

}
