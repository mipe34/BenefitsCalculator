using Api.Extensions;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class DependentAgeCosts : IDeductionCalculator
    {
        private readonly DateTime toDate;
        private readonly decimal monthlyCosts;
        private readonly int ageDiscriminator;

        public DependentAgeCosts(DateTime toDate, decimal monthlyCosts, int ageDiscriminator)
        {
            this.toDate = toDate;
            this.monthlyCosts = monthlyCosts;
            this.ageDiscriminator = ageDiscriminator;
        }

        public string Name => $"Over-{ageDiscriminator} Dependent Surcharge"; // TODO localize

        public decimal CalculateYearCosts(Employee employee)
        {
            var applyForPortionOfYear = employee.Dependents.Sum(x => x.DateOfBirth.PortionOfYearTurnedSelectedAge(toDate, ageDiscriminator));
            return monthlyCosts * 12m * applyForPortionOfYear;
        }

        public bool IsApplicable(Employee employee)
        {
            return employee.Dependents.Any(x => x.DateOfBirth.PortionOfYearTurnedSelectedAge(toDate, ageDiscriminator) > 0);
        }


    }
}
