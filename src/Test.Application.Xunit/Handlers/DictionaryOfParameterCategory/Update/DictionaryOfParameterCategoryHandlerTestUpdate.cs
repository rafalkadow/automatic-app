using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Shared.Helpers;
using Application.Modules.DictionaryOfParameterCategory.Update;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.DictionaryOfParameterCategory.Update
{
    public class DictionaryOfParameterCategoryHandlerTestUpdate : BaseHandlerBase
    {

        public DictionaryOfParameterCategoryHandlerTestUpdate()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public void Handler_ReturnsSuccess_Update(string guid)
        {
            var handler = new UpdateDictionaryOfParameterCategoryHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new UpdateDictionaryOfParameterCategoryCommand
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
            var handler = new UpdateDictionaryOfParameterCategoryHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new UpdateDictionaryOfParameterCategoryCommand
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