using AutoMapper;
using Application.Utilities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence.Context;
using Application.Modules.PlcDriverGroup.Mappings;
using Application.Modules.PlcDriver.Mappings;
using Application.Modules.SignIn.Mappings;

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
                //UserGuid = AccountConsts.RootId,
                //UserName = AccountConsts.RootName,
            };
            dataSeed();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new SignInProfile());
                //config.AddProfile(new AccountProfile());
                config.AddProfile(new PlcDriverGroupProfile());
                config.AddProfile(new PlcDriverProfile());
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        private void dataSeed()
        {
            if (_dbContext.Users.Any())
                return;

            //var testAccount = new List<AccountModel>()
            //{
            //    new AccountModel()
            //    {
            //        Id = new Guid("00000000-0000-0000-0000-000000000001"),
            //        AccountEmail = "test1@test.com",
            //        FirstName = "FirstName",
            //        LastName = "LastName",
            //        AccountPassword= "pass123".Encrypt(),
            //        AccountTypeId =  (int) AccountTypeEnum.Administrator,
            //        AccountTypeName =  AccountTypeEnum.Administrator.GetDescription(),
            //    },
            //    new AccountModel()
            //    {
            //        AccountEmail = "test2@test.com",
            //        FirstName = "FirstName",
            //        LastName = "LastName",
            //        AccountPassword= "pass123".Encrypt(),
            //        AccountTypeId =  (int) AccountTypeEnum.Administrator,
            //        AccountTypeName =  AccountTypeEnum.Administrator.GetDescription(),
            //    },
            //};

            //_dbContext.Account.AddRange(testAccount);
            //var generator = new RandomGenerator();


            //var testPlcDriverGroup = new List<PlcDriverGroupModel>();

            //for (int i = 0; i < 100; i++)
            //{
            //    var randomString = generator.RandomString(3);
            //    var item = new PlcDriverGroupModel()
            //    {
            //        Name = randomString,
            //        Description = randomString,
            //    };

            //    if (i == 0)
            //        item.Id = new Guid("00000000-0000-0000-0000-000000000001");

            //    testPlcDriverGroup.Add(item);
            //}

            //_dbContext.PlcDriverGroup.AddRange(testPlcDriverGroup);
            //_dbContext.SaveChanges();

            //var testPlcDriver = new List<PlcDriverModel>();
            //int j = 0;
            //foreach (var item in _dbContext.PlcDriverGroup)
            //{
            //    var randomString = generator.RandomString(3);
            //    var product = new PlcDriverModel()
            //    {
            //        Name = randomString,
            //        Description = randomString,
            //        PlcDriverGroupId = item.Id,
            //    };

            //    if (j == 0)
            //        product.Id = new Guid("00000000-0000-0000-0000-000000000001");

            //    testPlcDriver.Add(product);
            //    j++;
            //}

            //_dbContext.PlcDriver.AddRange(testPlcDriver);

            //_dbContext.SaveChanges();
        }
    }
}