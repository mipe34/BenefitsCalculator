using Api.Models;
using Api.Services.Deductions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiTests.UnitTests.Deductions
{
    public class DependenetMonthlyCostsUnitTests
    {
        [Fact]
        public void IsApplicable_ReturnsTrueWhenEmployeeHasDependents()
        {
            //arrange
            var deduction = new DependentMonthlyCosts(100);
            var employee = new Employee
            {
                Dependents = new List<Dependent> { new Dependent() }
            };

            //act
            var result = deduction.IsApplicable(employee);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsApplicable_ReturnsFalseWhenEmployeeHasNoDependents()
        {
            //arrange
            var deduction = new DependentMonthlyCosts(100);
            var employee = new Employee();

            //act
            var result = deduction.IsApplicable(employee);

            //assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1200)]
        [InlineData(2, 2400)]
        public void CalculateYearCosts_CalculatesRightValueForDependents(int numberOfDependents, decimal expected)
        {
            //arrange
            var deduction = new DependentMonthlyCosts(100);
            var employee = new Employee
            {
                Dependents = Enumerable.Repeat(new Dependent(), numberOfDependents).ToList()
            };

            //act
            var result = deduction.CalculateYearCosts(employee);

            //assert
            Assert.Equal(expected, result);
        }
    }
}
