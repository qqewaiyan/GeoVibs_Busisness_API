using GeoVibs_Busisness_API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GeoVibs_Busisness_API.Service.Room
{

    using DataEntity;
    public class RoomService : IRoomService
    {
        private readonly VenueDbContext _db;
        public RoomService(VenueDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteAsync(IdParam param)
        {
            var existingRoom = await GetByIdAsync(param);
            if (existingRoom != null)
            {
                _db.Rooms.Remove(existingRoom);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Room>> GetAllAsync(VenueParam param)
        {
            return await _db.Rooms.Where(x => x.VenueId == param.VenueId).AsNoTracking().ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(IdParam param)
        {
            return await _db.Rooms
                .FirstOrDefaultAsync(x => x.Id == param.Id && x.VenueId == param.VenueId);
        }

        public async Task<bool> SaveAsync(Room room)
        {
            try
            {
                var param = new IdParam { Id = room.Id, VenueId = room.VenueId };
                var existingRoom = await GetByIdAsync(param);

                if (existingRoom != null)
                    _db.Rooms.Update(room);
                else
                    _db.Rooms.Add(room);

                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }
    }
}
