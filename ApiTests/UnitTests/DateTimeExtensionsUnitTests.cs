using Api.Extensions;
using System;
using Xunit;

namespace ApiTests.UnitTests
{
    public class DateTimeExtensionsUnitTests
    {
        [Fact]
        public void PortionOfYearTurnedSelectedAge_ReturnsZeroWhenAgeNotReached()
        {
            //arrange
            var birthDay = new DateTime(2000, 01, 01);
            var toDate = new DateTime(2025, 01, 01);
            var age = 50;

            //act
            var result = birthDay.PortionOfYearTurnedSelectedAge(toDate, age);

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void PortionOfYearTurnedSelectedAge_ReturnsOneWhenAgeReachedMoreThanAYearBefore()
        {
            //arrange
            var birthDay = new DateTime(1950, 01, 01);
            var toDate = new DateTime(2025, 01, 01);
            var age = 50;

            //act
            var result = birthDay.PortionOfYearTurnedSelectedAge(toDate, age);

            //assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void PortionOfYearTurnedSelectedAge_ReturnsCorrectPortionOfYearWhenJustTurnedTheAge()
        {
            //arrange
            var birthDay = new DateTime(1975, 12, 31);
            var toDate = new DateTime(2025, 01, 01);
            var age = 50;

            //act
            var result = birthDay.PortionOfYearTurnedSelectedAge(toDate, age);

            //assert
            Assert.Equal(1m/365m, result);
        }

        //TODO extend test coverage
    }
}
