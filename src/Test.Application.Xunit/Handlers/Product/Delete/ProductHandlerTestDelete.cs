using Domain.Modules.Product.Commands;
using Application.Modules.Product.Delete;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.Product.Delete
{
    public class ProductHandlerTestDelete : BaseHandlerBase
    {

        public ProductHandlerTestDelete()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public void Handler_Success_Delete(string guid)
        {
            var handler = new DeleteProductHandler(_dbContext, _mapper, userAccessor);

            var item = new DeleteProductCommand
            {
                GuidList = new List<Guid> { new Guid(guid) },
            };

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.OperationStatus);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000002")]
        [InlineData("00000000-0000-0000-0000-000000000003")]
        [InlineData("00000000-0000-0000-0000-000000000004")]
        [InlineData("00000000-0000-0000-0000-000000000005")]
        public void Handler_Error_Delete(string guid)
        {
            var handler = new DeleteProductHandler(_dbContext, _mapper, userAccessor);

            var item = new DeleteProductCommand
            {
                GuidList = new List<Guid> { new Guid(guid) },
            };

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.False(result.OperationStatus);
        }
    }
}