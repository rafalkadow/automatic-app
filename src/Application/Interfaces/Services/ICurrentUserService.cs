using Application.Interfaces.Common;

namespace Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        Guid UserId { get; }
    }
}