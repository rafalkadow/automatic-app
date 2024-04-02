using Application.Interfaces.Common;
using Domain.Requests.Identity;
using Domain.Responses.Identity;
using Shared.Wrapper;

namespace Application.Interfaces.Services.Identity
{
    public interface IUserService : IService
    {
        Task<Result<List<UserResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<IResult<UserResponse>> GetAsync(Guid userId);

        Task<IResult> RegisterAsync(RegisterRequest request, string origin);

        Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        Task<IResult<UserRolesResponse>> GetRolesAsync(Guid id);

        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

        Task<IResult<string>> ConfirmEmailAsync(Guid userId, string code);

        Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);

        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

    }
}