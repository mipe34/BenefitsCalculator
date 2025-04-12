using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public class DeductionCalculatorFactory
    {
        public IEnumerable<IDeductionCalculator> GetDeductionCalculators(DateTime toDate)
        {
            return new IDeductionCalculator[]
            {
                // TODO read settings from configuration file or from other source (API/database)
                new MonthlyBenefitCosts(1000),
                new DependantMonthlyCosts(600),
                new ProgressiveSalaryCosts(80000, 2),
                new DependantAgeCosts(toDate, 200, 50)
            };
        }
    }
}
