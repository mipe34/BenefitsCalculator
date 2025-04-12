using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class DependantMonthlyCosts : DeductionsBase
    {
        private readonly decimal monthlyCost;

        public DependantMonthlyCosts(decimal monthlyCost)
        {
            this.monthlyCost = monthlyCost;
        }

        public override string Name => "Dependent Costs"; // TODO localize

        public override decimal CalculateYearCosts(Employee employee)
        {
            var dependentsCount = employee.Dependents.Count;
            var yearDependentsCost = dependentsCount * monthlyCost * 12;
            return yearDependentsCost;
        }

        public override bool IsApplicable(Employee employee)
        {
            return employee.Dependents.Any();
        }
    }
}
