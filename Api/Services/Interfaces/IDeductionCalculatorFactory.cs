namespace Api.Services.Interfaces
{
    public interface IDeductionCalculatorFactory
    {
        IEnumerable<IDeductionCalculator> GetDeductionCalculators(DateTime toDate);
    }
}
