namespace GeoVibs_Busisness_API.Service.UserLevel
{
    using DataEntity;
    using GeoVibs_Busisness_API.DataAccess;
    using GeoVibs_Busisness_API.Service.User;
    using Microsoft.EntityFrameworkCore;

    public class UserLevelService : IUserLevelService
    {
        private readonly VenueDbContext _db;
        public UserLevelService(VenueDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteAsync(IdParam param)
        {
            var existingUserLevel = await GetByIdAsync(param);
            if (existingUserLevel != null)
            {
                _db.UserLevels.Remove(existingUserLevel);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<UserLevel>> GetAllAsync(VenueParam param)
        {
            return await _db.UserLevels.Where(x => x.VenueId == param.VenueId).AsNoTracking().ToListAsync();
        }

        public async Task<UserLevel?> GetByIdAsync(IdParam param)
        {
            var existingUserLevel = await _db.UserLevels.FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            return existingUserLevel;
        }

        public async Task<UserLevel?> GetByIdWithNoTrackingAsync(IdParam param)
        {
            var existingUserLevel = await _db.UserLevels.AsNoTracking().FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            return existingUserLevel;
        }

        public async Task<bool> SaveAsync(UserLevel user)
        {
            try
            {
                var param = new IdParam { Id = user.Id, VenueId = user.VenueId };
                var existingUserLevel = await GetByIdAsync(param);
                if (existingUserLevel is not null)
                {
                    _db.UserLevels.Update(user);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _db.UserLevels.Add(user);
                    await _db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
