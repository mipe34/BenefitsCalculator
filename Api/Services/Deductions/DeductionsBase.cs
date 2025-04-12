using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Deductions
{
    public abstract class DeductionsBase : IDeductionCalculator
    {
        public abstract decimal CalculateYearCosts(Employee employee);

        public abstract bool IsApplicable(Employee employee);

        public abstract string Name { get; }

        public decimal CalculateCosts(Employee employee, decimal payPeriods)
        {
            return CalculateYearCosts(employee) / payPeriods;
        }
    }
}
