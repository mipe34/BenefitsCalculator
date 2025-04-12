using Api.Models;

namespace Api.Dtos.Paycheck
{
    public class GetPaycheckDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }

        public decimal GrossPay { get; set; }
        public decimal NetPayPreTax { get; set; }

        public List<GetDeductionDto> Deductions { get; set; }
        public decimal DeductionsTotal { get; set; }

        public GetPaycheckDto(
            int employeeId,
            string? employeeFirstName,
            string? employeeLastName,
            decimal grossPay,
            decimal netPayPreTax,
            List<GetDeductionDto> deductions,
            decimal deductionsTotal)
        {
            EmployeeId = employeeId;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            GrossPay = grossPay;
            NetPayPreTax = netPayPreTax;
            Deductions = deductions;
            DeductionsTotal = deductionsTotal;
        }
    }
}
