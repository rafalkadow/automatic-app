using Domain.Modules.SignIn.Commands;
using Shared.Helpers;
using Application.Modules.SignIn.Commands;
using Application.Modules.SignIn.Queries;
using Domain.Modules.SignIn.Queries;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.SignIn.Create
{
    public class SignInHandlerTest : BaseHandlerBase
    {

        public SignInHandlerTest()
            : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public async Task Handler_ReturnsSuccess_SigInAsync(string guid)
        {
            var handlerRead = new GetSignInQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var itemRead = new GetSignInQueryById(new Guid(guid));
            var resultRead = await handlerRead.Handle(itemRead, CancellationToken.None);
            Assert.NotNull(resultRead);
            var handler = new SignInHandler(_dbContext, _mapper, userAccessor);
            var item = new SignInCommand
            {
                SignInEmail = resultRead.EmailSignIn,
                SignInPassword = "pass123",
            };
            var result = await handler.Handle(item, CancellationToken.None);
            Assert.True(result.OperationStatus);
        }

        [Fact]
        public async Task Handler_ReturnsError_SigInAsync()
        {
            var handler = new SignInHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomString = generator.RandomString(6);

            var item = new SignInCommand
            {
                SignInEmail = randomString,
                SignInPassword = "pass123",
            };
            var result = await handler.Handle(item, CancellationToken.None);
            Assert.False(result.OperationStatus);
        }

    }
}