using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class MonthlyBenefitCosts : DeductionsBase
    {
        private readonly decimal YearCost;
        
        public MonthlyBenefitCosts(decimal monthlyCost)
        {
            YearCost = monthlyCost * 12;
        }

        public override string Name => "Base Benefit Costs"; // TODO localize

        public override decimal CalculateYearCosts(Employee employee)
        {
            return YearCost;
        }

        public override bool IsApplicable(Employee employee)
        {
            return true;
        }
    }
}
