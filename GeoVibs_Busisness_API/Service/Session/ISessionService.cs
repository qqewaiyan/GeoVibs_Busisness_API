namespace GeoVibs_Busisness_API.Service.Session
{
    using DataEntity;
    public interface ISessionService
    {
        Task<List<Session>> GetAllAsync(VenueParam param);
        Task<List<Session>> GetByDateAsync(SessionDateParam param);
        Task<Session?> GetByIdAsync(IdParam id);
        Task<bool> DeleteAsync(IdParam id);
        Task<SessionPreviewResponse> PreviewAsync(SessionPreviewRequest req);
    }
}
