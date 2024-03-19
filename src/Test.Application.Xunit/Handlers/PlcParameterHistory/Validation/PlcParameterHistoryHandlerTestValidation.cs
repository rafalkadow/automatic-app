using Application.Modules.PlcParameterHistory.Create;
using Domain.Modules.PlcParameterHistory.Commands;
using Domain.Modules.Base.Models;
using Shared.Enums;
using FluentValidation.TestHelper;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.PlcParameterHistory.Validation
{
    public class PlcParameterHistoryHandlerTestValidation : BaseHandlerBase
    {

        public PlcParameterHistoryHandlerTestValidation()
        : base()
        {
        }

        [Theory]
        [InlineData("name1", "")]
        [InlineData("", "code2")]
        [InlineData("", "")]
        public void Validate_Error(string name, string address)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreatePlcParameterHistoryCommand
            {
                Name = name,
                Address = address,
            };

            var validator = new CreatePlcParameterHistoryValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            // assert
            result.ShouldHaveAnyValidationError();
        }


        [Theory]
        [InlineData("name1", "code1")]
        [InlineData("name2", "code2")]
        [InlineData("name3", "code3")]
        [InlineData("name4", "code4")]
        public void Validate_Success(string name, string address)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreatePlcParameterHistoryCommand
            {
                Name = name,
                Address = address,
            };

            var validator = new CreatePlcParameterHistoryValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}