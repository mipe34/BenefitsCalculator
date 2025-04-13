using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class MonthlyBenefitCosts : IDeductionCalculator
    {
        private readonly decimal YearCost;
        
        public MonthlyBenefitCosts(decimal monthlyCost)
        {
            YearCost = monthlyCost * 12;
        }

        public string Name => "Base Benefit Costs"; // TODO localize

        public decimal CalculateYearCosts(Employee employee)
        {
            return YearCost;
        }

        public bool IsApplicable(Employee employee)
        {
            return true;
        }
    }
}
