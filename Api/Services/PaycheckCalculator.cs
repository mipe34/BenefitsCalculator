using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class PaycheckCalculator : IPaycheckCalculator
    {
        private readonly IDeductionCalculatorFactory deductionCalculatorFactory;

        public PaycheckCalculator(IDeductionCalculatorFactory deductionCalculatorFactory)
        {
            this.deductionCalculatorFactory = deductionCalculatorFactory;
        }

        public Paycheck CalculatePaycheck(Employee employee, int payPeriods, DateTime toDate)
        {
            var deductionCalculators = deductionCalculatorFactory.GetDeductionCalculators(toDate);

            var deductions = new List<Deduction>();
            foreach(var deductionCalculator in deductionCalculators)
            {
                if (deductionCalculator.IsApplicable(employee))
                {
                    var costs = deductionCalculator.CalculateCosts(employee, payPeriods);
                    deductions.Add(new Deduction(deductionCalculator.Name, costs));
                }
            }

            var deductionsTotal = deductions.Sum(x => x.Value);

            var grossPay = employee.Salary / payPeriods;
            var netPayPreTax = grossPay - deductionsTotal;

            return new Paycheck(employee.Id, employee.FirstName, employee.LastName, grossPay, netPayPreTax, deductions, deductionsTotal);
        }
    }
}
