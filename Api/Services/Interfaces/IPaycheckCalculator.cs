using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IPaycheckCalculator
    {
        Paycheck CalculatePaycheck(Employee employee, int payPeriods, DateTime toDate);
    }
}
