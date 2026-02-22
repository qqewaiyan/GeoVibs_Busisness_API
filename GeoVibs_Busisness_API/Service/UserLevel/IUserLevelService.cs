
namespace GeoVibs_Busisness_API.Service.UserLevel
{
    using DataEntity;
    public interface IUserLevelService
    {
        Task<List<UserLevel>> GetAllAsync(VenueParam param);
        Task<UserLevel?> GetByIdAsync(IdParam param);
        Task<UserLevel?> GetByIdWithNoTrackingAsync(IdParam param);
        Task<bool> SaveAsync(UserLevel user);
        Task<bool> DeleteAsync(IdParam param);
    }
}
