using Api.Dtos.Paycheck;
using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IPaycheckService
    {
        Task<Paycheck?> GetPaycheck(int employeeId, DateTime toDate);
    }
}
