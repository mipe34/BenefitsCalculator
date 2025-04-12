namespace Api.Dtos.Paycheck
{
    public class GetDeductionDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

        public GetDeductionDto(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
