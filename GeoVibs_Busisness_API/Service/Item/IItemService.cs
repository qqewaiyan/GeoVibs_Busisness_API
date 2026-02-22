namespace GeoVibs_Busisness_API.Service.Item
{
    using DataEntity;
    public interface IItemService
    {
        Task<List<Item>> GetAllAsync(VenueParam param);
        Task<Item?> GetByIdAsync(IdParam param);
        Task<bool> SaveAsync(Item room);
        Task<bool> DeleteAsync(IdParam param);
    }
}
