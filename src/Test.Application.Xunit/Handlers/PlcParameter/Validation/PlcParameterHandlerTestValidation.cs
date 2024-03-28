using Application.Modules.PlcParameter.Create;
using Domain.Modules.PlcParameter.Commands;
using Domain.Modules.Base.Models;
using Shared.Enums;
using FluentValidation.TestHelper;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.PlcParameter.Validation
{
    public class PlcParameterHandlerTestValidation : BaseHandlerBase
    {

        public PlcParameterHandlerTestValidation()
        : base()
        {
        }

        [Theory]
        [InlineData("name1", 100)]
        [InlineData("", 200)]
        [InlineData("", 300)]
        public void Validate_Error(string name, int address)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreatePlcParameterCommand
            {
                Name = name,
                Address = address,
            };

            var validator = new CreatePlcParameterValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            // assert
            result.ShouldHaveAnyValidationError();
        }


        [Theory]
        [InlineData("name1", 100)]
        [InlineData("name2", 100)]
        [InlineData("name3", 100)]
        [InlineData("name4", 100)]
        public void Validate_Success(string name, int address)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreatePlcParameterCommand
            {
                Name = name,
                Address = address,
            };

            var validator = new CreatePlcParameterValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}