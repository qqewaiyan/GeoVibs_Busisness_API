namespace GeoVibs_Busisness_API.Service.Item
{
    using DataEntity;
    using GeoVibs_Busisness_API.DataAccess;
    using GeoVibs_Busisness_API.Service.Item;
    using Microsoft.EntityFrameworkCore;

    public class ItemService : IItemService
    {
        private readonly VenueDbContext _db;
        public ItemService(VenueDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteAsync(IdParam param)
        {
            var existingItem = await GetByIdAsync(param);
            if (existingItem != null)
            {
                _db.Items.Remove(existingItem);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Item>> GetAllAsync(VenueParam param)
        {
            return await _db.Items.Where(x => x.VenueId == param.VenueId).AsNoTracking().ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(IdParam param)
        {
            var existingItem = await _db.Items.FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            return existingItem;
        }

        public async Task<Item?> GetByIdWithNoTrackingAsync(IdParam param)
        {
            var existingItem = await _db.Items.AsNoTracking().FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            return existingItem;
        }

        public async Task<bool> SaveAsync(Item movie)
        {
            try
            {
                var param = new IdParam() {  Id = movie.Id, VenueId = movie.VenueId };
                var existingItem = await GetByIdAsync(param);
                if (existingItem is not null)
                {
                    _db.Items.Update(movie);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _db.Items.Add(movie);
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
