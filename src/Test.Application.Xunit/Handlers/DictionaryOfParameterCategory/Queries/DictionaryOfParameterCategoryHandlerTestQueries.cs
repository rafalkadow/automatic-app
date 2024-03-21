using Shared.Helpers;
using Application.Modules.DictionaryOfParameterCategory.Queries;
using Domain.Modules.DictionaryOfParameterCategory.Queries;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.DictionaryOfParameterCategory.Queries
{
    public class DictionaryOfParameterCategoryHandlerTestQueries : BaseHandlerBase
    {

        public DictionaryOfParameterCategoryHandlerTestQueries()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public void Handler_ReturnsSuccess_GetId(string guid)
        {
            var handler = new GetDictionaryOfParameterCategoryQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var item = new GetDictionaryOfParameterCategoryQueryById(new Guid(guid));

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.Id == new Guid(guid));
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000002")]
        [InlineData("00000000-0000-0000-0000-000000000003")]
        [InlineData("00000000-0000-0000-0000-000000000004")]
        [InlineData("00000000-0000-0000-0000-000000000005")]
        public void Handler_ReturnsError_GetId(string guid)
        {
            var handler = new GetDictionaryOfParameterCategoryQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var item = new GetDictionaryOfParameterCategoryQueryById(new Guid(guid));

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result == null);
        }

        [Fact]
        public void Handler_ReturnsSuccess_GetAll()
        {
            var handler = new GetDictionaryOfParameterCategoryQueryAllHandler(_dbContext, _mapper, userAccessor);

            var item = new GetDictionaryOfParameterCategoryQueryAll();

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public void Handler_ReturnsError_GetAll()
        {
            var handler = new GetDictionaryOfParameterCategoryQueryAllHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);
            var item = new GetDictionaryOfParameterCategoryQueryAll();
            item.Name = randomString;
            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.Count() == 0);
        }
    }
}