using Domain.Modules.DictionaryOfParameterInterval.Commands;
using Shared.Helpers;
using Application.Modules.DictionaryOfParameterInterval.Update;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.DictionaryOfParameterInterval.Update
{
    public class DictionaryOfParameterIntervalHandlerTestUpdate : BaseHandlerBase
    {

        public DictionaryOfParameterIntervalHandlerTestUpdate()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public void Handler_ReturnsSuccess_Update(string guid)
        {
            var handler = new UpdateDictionaryOfParameterIntervalHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new UpdateDictionaryOfParameterIntervalCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Code = randomString
            };

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.OperationStatus);

        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000002")]
        [InlineData("00000000-0000-0000-0000-000000000003")]
        [InlineData("00000000-0000-0000-0000-000000000004")]
        [InlineData("00000000-0000-0000-0000-000000000005")]
        public void Handler_Error_Update(string guid)
        {
            var handler = new UpdateDictionaryOfParameterIntervalHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new UpdateDictionaryOfParameterIntervalCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Code = randomString
            };

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.False(result.OperationStatus);

        }
    }
}