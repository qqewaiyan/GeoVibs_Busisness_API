namespace GeoVibs_Busisness_API.Service.Movie
{
    using DataEntity;
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync(VenueParam param);
        Task<Movie?> GetByIdAsync(IdParam param);
        Task<bool> SaveAsync(Movie room);
        Task<bool> DeleteAsync(IdParam param);
    }
}
