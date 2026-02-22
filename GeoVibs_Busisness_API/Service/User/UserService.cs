namespace GeoVibs_Busisness_API.Service.User
{
    using DataEntity;
    using GeoVibs_Busisness_API.DataAccess;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly VenueDbContext _db;
        public UserService(VenueDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteAsync(IdParam param)
        {
            var existingUser = await GetByIdAsync(param);
            if (existingUser != null)
            {
                _db.Users.Remove(existingUser);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllAsync(VenueParam param)
        {
            return await _db.Users.Where(x => x.VenueId == param.VenueId).AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(IdParam param)
        {
            var existingUser = await _db.Users.FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            return existingUser;
        }

        public async Task<bool> SaveAsync(User user)
        {
            try
            {
                var param = new IdParam { Id = user.Id, VenueId = user.VenueId };
                var existingUser = await GetByIdAsync(param);
                if (existingUser is not null)
                {
                    _db.Users.Update(user);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _db.Users.Add(user);
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
