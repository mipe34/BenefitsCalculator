using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class ProgressiveSalaryCosts : DeductionsBase
    {
        private readonly decimal progressionSalaryFrom;
        private readonly decimal percentage;

        public ProgressiveSalaryCosts(decimal progressionSalaryLimit, decimal percentage)
        {
            this.progressionSalaryFrom = progressionSalaryLimit;
            this.percentage = percentage;
        }

        public override string Name => "High Earner Surcharge"; // TODO localize

        public override decimal CalculateYearCosts(Employee employee)
        {
            var yearProgressionCosts = employee.Salary * (percentage / 100m);
            return yearProgressionCosts;
        }

        public override bool IsApplicable(Employee employee)
        {
            return employee.Salary > progressionSalaryFrom;
        }
    }
}
