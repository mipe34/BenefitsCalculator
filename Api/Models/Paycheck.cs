namespace Api.Models
{
    public class Paycheck
    {
        public int EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
        public int PaycheckNumber { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPayPreTax { get; set; }
        public DateTime IssuedFrom { get; set; }
        public DateTime IssuedTo { get; set; }
    }
}
