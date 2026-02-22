namespace GeoVibs_Busisness_API.Service.Session
{
    using DataEntity;
    using GeoVibs_Busisness_API.DataAccess;
    using Microsoft.EntityFrameworkCore;

    public class SessionService : ISessionService
    {
        private readonly VenueDbContext _db;
        public SessionService(VenueDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteAsync(IdParam param)
        {
            var existingSession = await _db.Sessions.FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            if (existingSession != null)
            {
                _db.Sessions.Remove(existingSession);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Session>> GetAllAsync(VenueParam param)
        {
            return await _db.Sessions.Where(x => x.VenueId == param.VenueId).AsNoTracking().ToListAsync();
        }

        public async Task<List<Session>> GetByDateAsync(SessionDateParam param)
        {

            return await _db.Sessions
                .Where(x =>
                    x.VenueId == param.VenueId &&
                    x.StartAt >= param.FromDate &&
                    x.StartAt < param.ToDate
                )
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<Session?> GetByIdAsync(IdParam param)
        {
            var existingSession = await _db.Sessions.FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);
            return existingSession;
        }

        public async Task<Session?> GetByIdWithNoTrackingAsync(IdParam param)
        {
            return await _db.Sessions.AsNoTracking().FirstOrDefaultAsync(r => r.Id == param.Id && r.VenueId == param.VenueId);

        }

        public async Task<SessionPreviewResponse> PreviewAsync(SessionPreviewRequest req)
        {
            var room = await _db.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == req.RoomId && x.VenueId == req.VenueId);

            if (room == null)
                throw new Exception("Room not found");

            var movie = await _db.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == req.MovieId);

            if (movie == null || movie.DurationMinutes <= 0)
                throw new Exception("Invalid movie");

            // Calculate duration & end time
            var durationMinutes = movie.DurationMinutes;
            var expectedEnd = req.StartAt.AddMinutes(durationMinutes);

            // Overlap validation
            var hasConflict = await _db.Sessions.AnyAsync(s =>
                s.RoomId == req.RoomId &&
                s.Status != SessionStatus.Cancelled &&
                req.StartAt < s.ExpectedEndAt &&
                expectedEnd > s.StartAt
            );

            if (hasConflict)
                throw new Exception("Session overlaps with existing booking");

            // Pricing
            var hoursCharged = (int)Math.Ceiling(durationMinutes / 60m);
            var roomCharge = hoursCharged * room.BaseHourlyRate;
            var total = roomCharge + req.ExtraCharge;

            return new SessionPreviewResponse
            {
                ExpectedEndAt = expectedEnd,
                DurationMinutes = durationMinutes,
                HoursCharged = hoursCharged,
                RoomCharge = roomCharge,
                Total = total
            };
        }

    }
}
