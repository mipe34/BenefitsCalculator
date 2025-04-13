using Api.Services.Deductions;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class DeductionCalculatorFactory : IDeductionCalculatorFactory
    {
        public IEnumerable<IDeductionCalculator> GetDeductionCalculators(DateTime toDate)
        {
            return new IDeductionCalculator[]
            {
                // TODO read settings from configuration file or from other source (API/database)
                new MonthlyBenefitCosts(1000),
                new DependentMonthlyCosts(600),
                new ProgressiveSalaryCosts(80000, 2),
                new DependentAgeCosts(toDate, 200, 50)
            };
        }
    }
}
