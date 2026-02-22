using GeoVibs_Busisness_API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GeoVibs_Busisness_API.Service.Movie
{

    using DataEntity;
    public class MovieService : IMovieService
    {
        private readonly VenueDbContext _db;
        public MovieService(VenueDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteAsync(IdParam param)
        {
            var existingMovie = await GetByIdAsync(param);
            if (existingMovie != null)
            {
                _db.Movies.Remove(existingMovie);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Movie>> GetAllAsync(VenueParam param)
        {
            return await _db.Movies.Where(x => x.VenueId == param.VenueId).AsNoTracking().ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(IdParam param)
        {
            return await _db.Movies
                .FirstOrDefaultAsync(x => x.Id == param.Id && x.VenueId == param.VenueId);
        }

        public async Task<bool> SaveAsync(Movie movie)
        {
            try
            {
                var param = new IdParam { Id = movie.Id, VenueId = movie.VenueId };
                var existingMovie = await GetByIdAsync(param);

                if (existingMovie != null)
                    _db.Movies.Update(movie);
                else
                    _db.Movies.Add(movie);

                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
