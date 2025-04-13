using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IDeductionCalculator
    {
        decimal CalculateYearCosts(Employee employee);

        bool IsApplicable(Employee employee);

        string Name { get; }
    }
}
