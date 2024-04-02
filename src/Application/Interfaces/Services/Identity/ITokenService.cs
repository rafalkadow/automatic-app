using Application.Interfaces.Common;
using Domain.Requests.Identity;
using Domain.Responses.Identity;
using Shared.Wrapper;

namespace Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}