using Application.Modules.SignIn.Queries;
using Domain.Modules.SignIn.Queries;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.SignIn.Queries
{
    public class SignInHandlerTestQueries : BaseHandlerBase
    {

        public SignInHandlerTestQueries()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public async Task Handler_ReturnsSuccess_GetIdAsync(string guid)
        {
            var handler = new GetSignInQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var item = new GetSignInQueryById(new Guid(guid));

            var result = await handler.Handle(item, CancellationToken.None);
            Assert.True(result.Id == new Guid(guid));
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000002")]
        [InlineData("00000000-0000-0000-0000-000000000003")]
        [InlineData("00000000-0000-0000-0000-000000000004")]
        [InlineData("00000000-0000-0000-0000-000000000005")]
        public async Task Handler_ReturnsError_GetIdAsync(string guid)
        {
            var handler = new GetSignInQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var item = new GetSignInQueryById(new Guid(guid));

            var result = await handler.Handle(item, CancellationToken.None);
            Assert.True(result == null);
        }
    }
}