using Application.Modules.DictionaryOfParameterCategory.Create;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Shared.Helpers;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.DictionaryOfParameterCategory.Create
{
    public class DictionaryOfParameterCategoryHandlerTestCreate : BaseHandlerBase
    {

        public DictionaryOfParameterCategoryHandlerTestCreate()
        : base()
        {
        }

        [Fact]
        public async Task Handler_ReturnsSuccess_CreateAsync()
        {
            var handler = new CreateDictionaryOfParameterCategoryHandler(_dbContext, _mapper, userAccessor);
            int DictionaryOfParameterCategoryCount = _dbContext.DictionaryOfParameterCategory.Count();
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            
            var countRecord = 100;

            for (int i = 0; i < countRecord; i++)
            {
                var randomString = generator.RandomString(3);
                var item = new CreateDictionaryOfParameterCategoryCommand
                {
                    Name = randomString,
                    Code = randomString,
                };

                var result = await handler.Handle(item, CancellationToken.None);
                Assert.True(result.OperationStatus);
            }

            Assert.Equal(DictionaryOfParameterCategoryCount + countRecord, _dbContext.DictionaryOfParameterCategory.Count());
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public async Task Handler_ReturnsError_CreateAsync(string guid)
        {
            var handler = new CreateDictionaryOfParameterCategoryHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new CreateDictionaryOfParameterCategoryCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Code = randomString,
            };
            var exception = await Assert.ThrowsAnyAsync<Exception>(() => handler.Handle(item, CancellationToken.None));
            Assert.True(!string.IsNullOrEmpty(exception.Message));
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000002")]
        [InlineData("00000000-0000-0000-0000-000000000003")]
        [InlineData("00000000-0000-0000-0000-000000000004")]
        public async Task Handler_ReturnsError2_CreateAsync(string guid)
        {
            var handler = new CreateDictionaryOfParameterCategoryHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new CreateDictionaryOfParameterCategoryCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Code = randomString,
            };
            var result = await handler.Handle(item, CancellationToken.None);
            Assert.True(result.OperationStatus);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => handler.Handle(item, CancellationToken.None));
            Assert.True(!string.IsNullOrEmpty(exception.Message));
        }
    }
}