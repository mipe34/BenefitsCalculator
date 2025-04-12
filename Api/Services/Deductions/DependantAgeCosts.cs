using Api.Extensions;
using Api.Models;

namespace Api.Services.Deductions
{
    public class DependantAgeCosts : DeductionsBase
    {
        private readonly DateTime toDate;
        private readonly decimal monthlyCosts;
        private readonly int ageDiscriminator;

        public DependantAgeCosts(DateTime toDate, decimal monthlyCosts, int ageDiscriminator)
        {
            this.toDate = toDate;
            this.monthlyCosts = monthlyCosts;
            this.ageDiscriminator = ageDiscriminator;
        }

        public override string Name => $"Over-{ageDiscriminator} Dependent Surcharge"; // TODO localize

        public override decimal CalculateYearCosts(Employee employee)
        {
            var applyForMonthsCount = employee.Dependents.Sum(x => x.DateOfBirth.MonthsOfYearTurnedSelectedAge(toDate, ageDiscriminator));
            return monthlyCosts * new Decimal(applyForMonthsCount);
        }

        public override bool IsApplicable(Employee employee)
        {
            return employee.Dependents.Any(x => x.DateOfBirth.MonthsOfYearTurnedSelectedAge(toDate, ageDiscriminator) > 0);
        }


    }
}
