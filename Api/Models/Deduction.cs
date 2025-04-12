namespace Api.Models
{
    public class Deduction
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public Deduction(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
