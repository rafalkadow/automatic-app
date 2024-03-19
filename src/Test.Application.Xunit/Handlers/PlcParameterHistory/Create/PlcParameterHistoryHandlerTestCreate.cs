using Application.Modules.PlcParameterHistory.Create;
using Domain.Modules.PlcParameterHistory.Commands;
using Shared.Helpers;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.PlcParameterHistory.Create
{
    public class PlcParameterHistoryHandlerTestCreate : BaseHandlerBase
    {

        public PlcParameterHistoryHandlerTestCreate()
        : base()
        {
        }

        [Fact]
        public async Task Handler_ReturnsSuccess_CreateAsync()
        {
            var handler = new CreatePlcParameterHistoryHandler(_dbContext, _mapper, userAccessor);
            int PlcParameterHistoryCount = _dbContext.PlcParameterHistory.Count();
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            
            var countRecord = 100;

            for (int i = 0; i < countRecord; i++)
            {
                var randomString = generator.RandomString(3);
                var item = new CreatePlcParameterHistoryCommand
                {
                    Name = randomString,
                    Address = randomString,
                };

                var result = await handler.Handle(item, CancellationToken.None);
                Assert.True(result.OperationStatus);
            }

            Assert.Equal(PlcParameterHistoryCount + countRecord, _dbContext.PlcParameterHistory.Count());
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public async Task Handler_ReturnsError_CreateAsync(string guid)
        {
            var handler = new CreatePlcParameterHistoryHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new CreatePlcParameterHistoryCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Address = randomString,
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
            var handler = new CreatePlcParameterHistoryHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new CreatePlcParameterHistoryCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Address = randomString,
            };
            var result = await handler.Handle(item, CancellationToken.None);
            Assert.True(result.OperationStatus);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => handler.Handle(item, CancellationToken.None));
            Assert.True(!string.IsNullOrEmpty(exception.Message));
        }
    }
}