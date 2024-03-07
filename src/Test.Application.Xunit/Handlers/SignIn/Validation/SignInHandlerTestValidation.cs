using Domain.Modules.SignIn.Commands;
using Domain.Modules.Base.Models;
using Shared.Enums;
using FluentValidation.TestHelper;
using Application.Modules.SignIn.Validations;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.SignIn.Validation
{
    public class SignInHandlerTestValidation : BaseHandlerBase
    {
        public SignInHandlerTestValidation()
        : base()
        {
        }

        [Theory]
        [InlineData("name1", "")]
        [InlineData("", "code2")]
        [InlineData("", "")]
        public void Validate_Error(string email, string password)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new SignInCommand
            {
                SignInEmail = email,
                SignInPassword = password,
            };

            var validator = new SignInValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            // assert
            result.ShouldHaveAnyValidationError();
        }


        [Theory]
        [InlineData("test1@test.com", "pass123")]
        public void Validate_Success(string email, string password)
        {
            // arrange
            var definitionModel = new DefinitionModel(OperationEnum.Create, userAccessor);

            var model = new SignInCommand
            {
                SignInEmail = email,
                SignInPassword = password,
            };

            var validator = new SignInValidation(_dbContext, definitionModel);

            // act
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}