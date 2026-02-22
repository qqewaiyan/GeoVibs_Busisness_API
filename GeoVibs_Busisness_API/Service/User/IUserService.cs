namespace GeoVibs_Busisness_API.Service.User
{
    using DataEntity;
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(VenueParam param);
        Task<User?> GetByIdAsync(IdParam param);
        Task<User?> GetByIdWithNoTrackingAsync(IdParam param);
        Task<bool> SaveAsync(User user);
        Task<bool> DeleteAsync(IdParam param);
    }
}
