using Api.Models;
using Api.Services;
using Api.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.UnitTests
{
    public class PaycheckCalculatorUnitTests
    {
        //TODO: expand test coverage

        [Fact]
        public void CalculatePaycheck_ReturnsCalculatesDeductionsAndNetPreTaxPay()
        {
            //arrange         
            var deductionCalcFactoryMock = new Mock<IDeductionCalculatorFactory>();
            deductionCalcFactoryMock.Setup(x => x.GetDeductionCalculators(It.IsAny<DateTime>())).Returns(SetupDeductionMocks());
            var calculator = new PaycheckCalculator(deductionCalcFactoryMock.Object);

            var employee = new Employee
            {
                FirstName = "FirstName1",
                LastName = "LastName2",
                Id = 1,
                Salary = 100000m
            };

            //act 
            var paycheck = calculator.CalculatePaycheck(employee, 10, DateTime.Now);

            //assert
            Assert.Equal("FirstName1", paycheck.EmployeeFirstName);
            Assert.Equal("LastName2", paycheck.EmployeeLastName);
            Assert.Equal(1, paycheck.EmployeeId);
            Assert.Equal(10000m, paycheck.GrossPay);
            Assert.Equal(110m, paycheck.DeductionsTotal);
            Assert.Equal(9890m, paycheck.NetPayPreTax);

            Assert.Equal(2, paycheck.Deductions.Count);
            Assert.Equal("1000", paycheck.Deductions[0].Name);
            Assert.Equal(100, paycheck.Deductions[0].Value);
            Assert.Equal("100", paycheck.Deductions[1].Name);
            Assert.Equal(10, paycheck.Deductions[1].Value);
        }

        private IEnumerable<IDeductionCalculator> SetupDeductionMocks()
        {
            var deductions = new List<IDeductionCalculator>();
            var deductionMock = new Mock<IDeductionCalculator>();
            deductionMock.Setup(x => x.IsApplicable(It.IsAny<Employee>())).Returns(true);
            deductionMock.Setup(x => x.CalculateYearCosts(It.IsAny<Employee>())).Returns(1000m);
            deductionMock.Setup(x => x.Name).Returns("1000");
            deductions.Add(deductionMock.Object);

            deductionMock = new Mock<IDeductionCalculator>();
            deductionMock.Setup(x => x.IsApplicable(It.IsAny<Employee>())).Returns(true);
            deductionMock.Setup(x => x.CalculateYearCosts(It.IsAny<Employee>())).Returns(100m);
            deductionMock.Setup(x => x.Name).Returns("100");
            deductions.Add(deductionMock.Object);

            deductionMock = new Mock<IDeductionCalculator>();
            deductionMock.Setup(x => x.IsApplicable(It.IsAny<Employee>())).Returns(false);
            deductionMock.Setup(x => x.Name).Returns("Not applicable");
            deductionMock.Setup(x => x.CalculateYearCosts(It.IsAny<Employee>())).Returns(100m);
            deductions.Add(deductionMock.Object);

            return deductions;
        }
    }
}
