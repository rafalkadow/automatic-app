using AutoMapper;
using Application.Modules.Account.Mappings;
using Application.Utilities;
using Domain.Interfaces;
using Domain.Modules.Account;
using Domain.Modules.Account.Consts;
using Domain.Modules.CategoryOfProduct.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Modules.Base.Enums;
using Persistence.Context;
using Shared.Extensions.EnumExtensions;
using Shared.Helpers;
using Application.Modules.CategoryOfProduct.Mappings;
using Domain.Modules.Product.Models;
using Application.Modules.Product.Mappings;
using Application.Modules.SignIn.Mappings;
using Application.Extensions;

namespace Test.Application.xUnit.Handlers.Base
{
    public class BaseHandlerBase
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IUserAccessor userAccessor;
        protected readonly IMapper _mapper;

        public BaseHandlerBase()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .EnableSensitiveDataLogging(true)
                 .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            _dbContext = new ApplicationDbContext(builder.Options, null, null);
            userAccessor = new UserAccessor
            {
                UserGuid = AccountConsts.RootId,
                UserName = AccountConsts.RootName,
            };
            dataSeed();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new SignInProfile());
                config.AddProfile(new AccountProfile());
                config.AddProfile(new CategoryOfProductProfile());
                config.AddProfile(new ProductProfile());
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        private void dataSeed()
        {
            if (_dbContext.Account.Any())
                return;

            var testAccount = new List<AccountModel>()
            {
                new AccountModel()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    AccountEmail = "test1@test.com",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    AccountPassword= "pass123".Encrypt(),
                    AccountTypeId =  (int) AccountTypeEnum.Administrator,
                    AccountTypeName =  AccountTypeEnum.Administrator.GetDescription(),
                },
                new AccountModel()
                {
                    AccountEmail = "test2@test.com",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    AccountPassword= "pass123".Encrypt(),
                    AccountTypeId =  (int) AccountTypeEnum.Administrator,
                    AccountTypeName =  AccountTypeEnum.Administrator.GetDescription(),
                },
            };

            _dbContext.Account.AddRange(testAccount);
            var generator = new RandomGenerator();


            var testCategoryOfProduct = new List<CategoryOfProductModel>();

            for (int i = 0; i < 100; i++)
            {
                var randomString = generator.RandomString(3);
                var item = new CategoryOfProductModel()
                {
                    Name = randomString,
                    Code = randomString,
                };

                if (i == 0)
                    item.Id = new Guid("00000000-0000-0000-0000-000000000001");

                testCategoryOfProduct.Add(item);
            }

            _dbContext.CategoryOfProduct.AddRange(testCategoryOfProduct);
            _dbContext.SaveChanges();

            var testProduct = new List<ProductModel>();
            int j = 0;
            foreach (var item in _dbContext.CategoryOfProduct)
            {
                var randomString = generator.RandomString(3);
                var product = new ProductModel()
                {
                    Name = randomString,
                    Code = randomString,
                    CategoryOfProductId = item.Id,
                };

                if (j == 0)
                    product.Id = new Guid("00000000-0000-0000-0000-000000000001");

                testProduct.Add(product);
                j++;
            }

            _dbContext.Product.AddRange(testProduct);

            _dbContext.SaveChanges();
        }
    }
}