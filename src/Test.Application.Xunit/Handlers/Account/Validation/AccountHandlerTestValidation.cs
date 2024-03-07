using Domain.Modules.Account.Commands;
using Domain.Modules.Base.Models;
using Shared.Enums;
using FluentValidation.TestHelper;
using Domain.Modules.Base.Enums;
using Application.Modules.Account.Validations;
using Shared.Extensions.EnumExtensions;
using Test.Application.xUnit.Handlers.Base;
using Microsoft.AspNetCore.Routing;

namespace Test.Application.Xunit.Handlers.Account.Validation
{
    public class AccountHandlerTestValidation : BaseHandlerBase
    {

        public AccountHandlerTestValidation()
        : base()
        {
        }

        [Theory]
        [InlineData("name1", "")]
        [InlineData("", "code2")]
        [InlineData("", "")]
        public void Validate_Error(string name, string code)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreateAccountCommand
            {
                AccountEmail = name,
                AccountPassword = code,
                AccountTypeId = (int)AccountTypeEnum.Administrator,
                AccountTypeName = AccountTypeEnum.Administrator.GetDescription(),
            };

            var validator = new CreateAccountValidation(_dbContext, definitionModel);

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
        public void Validate_Success(string name, string code)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreateAccountCommand
            {
                AccountEmail = name,
                AccountPassword = code,
                AccountTypeId = (int)AccountTypeEnum.Administrator,
                AccountTypeName = AccountTypeEnum.Administrator.GetDescription(),
            };

            var validator = new CreateAccountValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001", "name1", "code1")]
        public void Validate_Error_Guid(string guid, string name, string code)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new CreateAccountCommand
            {
                Id = new Guid(guid),
                AccountEmail = name,
                AccountPassword = code,
                AccountTypeId = (int)AccountTypeEnum.Administrator,
                AccountTypeName = AccountTypeEnum.Administrator.GetDescription(),
            };

            var validator = new CreateAccountValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }
    }
}