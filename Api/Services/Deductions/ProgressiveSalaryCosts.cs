using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class ProgressiveSalaryCosts : IDeductionCalculator
    {
        private readonly decimal progressionSalaryFrom;
        private readonly decimal percentage;

        public ProgressiveSalaryCosts(decimal progressionSalaryLimit, decimal percentage)
        {
            this.progressionSalaryFrom = progressionSalaryLimit;
            this.percentage = percentage;
        }

        public string Name => "High Earner Surcharge"; // TODO localize

        public decimal CalculateYearCosts(Employee employee)
        {
            var yearProgressionCosts = employee.Salary * (percentage / 100m);
            return yearProgressionCosts;
        }

        public bool IsApplicable(Employee employee)
        {
            return employee.Salary > progressionSalaryFrom;
        }
    }
}
