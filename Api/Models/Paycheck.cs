﻿namespace Api.Models
{
    public class Paycheck
    {
        public int EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }

        public decimal GrossPay { get; set; }
        public decimal NetPayPreTax { get; set; }

        public List<Deduction> Deductions { get; set; }
        public decimal DeductionsTotal { get; set; }

        public Paycheck(
            int employeeId, 
            string? employeeFirstName, 
            string? employeeLastName, 
            decimal grossPay, 
            decimal netPayPreTax, 
            List<Deduction> deductions,
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
