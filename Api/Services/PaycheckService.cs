using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class PaycheckService : IPaycheckService
    {
        private readonly IEmployeesRepository employeesRepository;
        private readonly IPaycheckCalculator paycheckCalculator;

        public PaycheckService(IEmployeesRepository employeesRepository, IPaycheckCalculator paycheckCalculator)
        {
            this.employeesRepository = employeesRepository;
            this.paycheckCalculator = paycheckCalculator;
        }

        public async Task<Paycheck?> GetPaycheck(int employeeId, DateTime toDate)
        {
            var employeeModel = await employeesRepository.FindEmployee(employeeId);
            if(employeeModel == null)
            {
                return null;
            }

            //TOOD get period days from config or other source (database/API)
            var paycheck = paycheckCalculator.CalculatePaycheck(employeeModel, 26, toDate);
            return paycheck;
        }
    }
}
