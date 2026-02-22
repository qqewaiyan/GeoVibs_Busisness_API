using DataEntity;
using GeoVibs_Busisness_API.Service.TokenGeneration;
using GeoVibs_Busisness_API.Service.Venue;
using Microsoft.AspNetCore.Identity;

namespace GeoVibs_Busisness_API.Service.Auth
{
    using DataEntity;
    using GeoVibs_Busisness_API.DataAccess;
    using GeoVibs_Busisness_API.Service.User;
    using Microsoft.EntityFrameworkCore;

    public class AuthService : IAuthService
    {
        private readonly VenueDbContext _db;
        private readonly PasswordHasher _passwordHasher;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(
            VenueDbContext db,
            PasswordHasher passwordHasher,
            JwtTokenGenerator jwt)
        {
            _db = db;
            _passwordHasher = passwordHasher;
            _jwt = jwt;
        }
        public async Task<string?> RegisterAsync(RegisterRequestParam param)
        {
            var existing = await _db.Venues
                .FirstOrDefaultAsync(v => v.Phone == param.Phone);

            if (existing != null)
                return "Phone number is already registered.";

            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                #region VenueCreation

                var venue = new Venue
                {
                    Name = param.VenueName,
                    Phone = param.Phone,
                    Type = param.VenueType,
                    CreatedAt = DateTime.UtcNow
                };

                _db.Venues.Add(venue);
                await _db.SaveChangesAsync();

                #endregion

                #region RoomCreation

                var room = new Room
                {
                    VenueId = venue.Id,
                    Status = RoomStatus.Available,
                    Name = "Room 101",
                    Feature= string.Empty,
                    CreatedAt = DateTime.UtcNow
                };

                _db.Rooms.Add(room);
                await _db.SaveChangesAsync();
                #endregion

                #region UserLevel

                var userLevel = new UserLevel
                {
                    Name = "Administor",
                    VenueId = venue.Id,
                };

                _db.UserLevels.Add(userLevel);
                await _db.SaveChangesAsync();

                #endregion

                #region UserCreation

                var user = new User
                {
                    Name = param.UserName,
                    Phone = param.Phone,
                    VenueId = venue.Id,
                    UserLevelId = userLevel.Id,
                    PasswordHash = _passwordHasher.HashPassword(param.Password),
                    CreatedAt = DateTime.UtcNow,
                    Email = string.Empty,
                };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                #endregion


                await tx.CommitAsync();
                return null;
            }
            catch(Exception ex)
            {
                await tx.RollbackAsync();
                return ex.Message;
                throw;
            }
        }
        public async Task<LoginInfo> LoginAsync(LoginRequestParam param)
        {
            var user = await _db.Users.FirstOrDefaultAsync(v => v.Phone == param.PhoneNumber);

            if (user == null || !_passwordHasher.VerifyPassword(param.Password, user.PasswordHash ?? string.Empty))
            {
                return new LoginInfo
                {
                    IsSuccess = false,
                    Token = string.Empty,
                    CurrentVenue = null
                };
            }
            var venue = await _db.Venues.FirstOrDefaultAsync(x => x.Id == user.VenueId);
            string token = _jwt.GenerateToken(user.Phone);

            return new LoginInfo
            {
                IsSuccess = true,
                Token = token,
                CurrentVenue = venue
            };
        }

    }


        

}
