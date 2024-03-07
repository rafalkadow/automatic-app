using Application.Modules.PlcDriverGroup.Create;
using Domain.Modules.PlcDriverGroup.Commands;
using Shared.Helpers;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.PlcDriverGroup.Create
{
    public class PlcDriverGroupHandlerTestCreate : BaseHandlerBase
    {

        public PlcDriverGroupHandlerTestCreate()
        : base()
        {
        }

        [Fact]
        public async Task Handler_ReturnsSuccess_CreateAsync()
        {
            var handler = new CreatePlcDriverGroupHandler(_dbContext, _mapper, userAccessor);
            int PlcDriverGroupCount = _dbContext.PlcDriverGroup.Count();
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            
            var countRecord = 100;

            for (int i = 0; i < countRecord; i++)
            {
                var randomString = generator.RandomString(3);
                var item = new CreatePlcDriverGroupCommand
                {
                    Name = randomString,
                    Description = randomString,
                };

                var result = await handler.Handle(item, CancellationToken.None);
                Assert.True(result.OperationStatus);
            }

            Assert.Equal(PlcDriverGroupCount + countRecord, _dbContext.PlcDriverGroup.Count());
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public async Task Handler_ReturnsError_CreateAsync(string guid)
        {
            var handler = new CreatePlcDriverGroupHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new CreatePlcDriverGroupCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Description = randomString,
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
            var handler = new CreatePlcDriverGroupHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new CreatePlcDriverGroupCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Description = randomString,
            };
            var result = await handler.Handle(item, CancellationToken.None);
            Assert.True(result.OperationStatus);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => handler.Handle(item, CancellationToken.None));
            Assert.True(!string.IsNullOrEmpty(exception.Message));
        }
    }
}