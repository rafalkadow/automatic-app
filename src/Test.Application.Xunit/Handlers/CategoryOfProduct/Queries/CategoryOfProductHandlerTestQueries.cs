using Shared.Helpers;
using Application.Modules.CategoryOfProduct.Queries;
using Domain.Modules.CategoryOfProduct.Queries;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.CategoryOfProduct.Queries
{
    public class CategoryOfProductHandlerTestQueries : BaseHandlerBase
    {

        public CategoryOfProductHandlerTestQueries()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public void Handler_ReturnsSuccess_GetId(string guid)
        {
            var handler = new GetCategoryOfProductQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var item = new GetCategoryOfProductQueryById(new Guid(guid));

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
            var handler = new GetCategoryOfProductQueryByIdHandler(_dbContext, _mapper, userAccessor);

            var item = new GetCategoryOfProductQueryById(new Guid(guid));

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result == null);
        }

        [Fact]
        public void Handler_ReturnsSuccess_GetAll()
        {
            var handler = new GetCategoryOfProductQueryAllHandler(_dbContext, _mapper, userAccessor);

            var item = new GetCategoryOfProductQueryAll();

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public void Handler_ReturnsError_GetAll()
        {
            var handler = new GetCategoryOfProductQueryAllHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);
            var item = new GetCategoryOfProductQueryAll();
            item.Name = randomString;
            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.Count() == 0);
        }
    }
}