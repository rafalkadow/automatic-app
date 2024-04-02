using Application.Interfaces.Common;
using Domain.Requests.Identity;
using Shared.Wrapper;

namespace Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, Guid userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, Guid userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

    }
}