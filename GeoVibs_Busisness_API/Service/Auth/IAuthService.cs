using DataEntity;

namespace GeoVibs_Busisness_API.Service.Auth
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterRequestParam param);
    }
}
