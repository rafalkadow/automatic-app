﻿using Domain.Modules.PlcDriverAlarm.Commands;
using Shared.Helpers;
using Application.Modules.PlcDriverAlarm.Update;
using Test.Application.xUnit.Handlers.Base;

namespace Test.Application.Xunit.Handlers.PlcDriverAlarm.Update
{
    public class PlcDriverAlarmHandlerTestUpdate : BaseHandlerBase
    {

        public PlcDriverAlarmHandlerTestUpdate()
        : base()
        {
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000001")]
        public void Handler_ReturnsSuccess_Update(string guid)
        {
            var handler = new UpdatePlcDriverAlarmHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new UpdatePlcDriverAlarmCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Description = randomString
            };

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.True(result.OperationStatus);

        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000002")]
        [InlineData("00000000-0000-0000-0000-000000000003")]
        [InlineData("00000000-0000-0000-0000-000000000004")]
        [InlineData("00000000-0000-0000-0000-000000000005")]
        public void Handler_Error_Update(string guid)
        {
            var handler = new UpdatePlcDriverAlarmHandler(_dbContext, _mapper, userAccessor);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(5, 100);
            var randomString = generator.RandomString(3);

            var item = new UpdatePlcDriverAlarmCommand
            {
                Id = new Guid(guid),
                Name = randomString,
                Description = randomString
            };

            var result = handler.Handle(item, CancellationToken.None).Result;
            Assert.False(result.OperationStatus);

        }
    }
}