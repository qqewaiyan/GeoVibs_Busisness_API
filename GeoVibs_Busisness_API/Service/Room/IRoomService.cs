namespace GeoVibs_Busisness_API.Service.Room
{
    using DataEntity;
    public interface IRoomService
    {
        Task<List<Room>> GetAllAsync(VenueParam param);
        Task<Room?> GetByIdAsync(IdParam param);
        Task<bool> SaveAsync(Room room);
        Task<bool> DeleteAsync(IdParam param);
    }
}
