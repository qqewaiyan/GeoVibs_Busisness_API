
namespace GeoVibs_Busisness_API.Service.Venue
{
    using DataEntity;
    public interface IVenueService
    {
        Task<List<Venue>> GetAllAsync();
        Task<Venue?> GetByIdAsync(int id);
        Task<Venue?> GetByIdWithNoTrackingAsync(int id);
        Task<bool> SaveAsync(Venue venue);
        Task<bool> DeleteAsync(int id);
        Task<Venue?> GetByPhoneNumberAsync(string ph);
    }
}
