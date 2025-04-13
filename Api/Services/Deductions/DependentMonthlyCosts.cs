using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class DependentMonthlyCosts : IDeductionCalculator
    {
        private readonly decimal monthlyCost;

        public DependentMonthlyCosts(decimal monthlyCost)
        {
            this.monthlyCost = monthlyCost;
        }

        public string Name => "Dependent Costs"; // TODO localize

        public decimal CalculateYearCosts(Employee employee)
        {
            var dependentsCount = employee.Dependents.Count;
            var yearDependentsCost = dependentsCount * monthlyCost * 12;
            return yearDependentsCost;
        }

        public bool IsApplicable(Employee employee)
        {
            return employee.Dependents.Any();
        }
    }
}
