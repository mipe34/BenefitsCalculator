using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IDeductionCalculator
    {
        decimal CalculateCosts(Employee employee, decimal payPeriods);

        bool IsApplicable(Employee employee);
    }
}
