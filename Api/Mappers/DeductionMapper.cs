using Api.Dtos.Paycheck;
using Api.Mappers.Interfaces;
using Api.Models;

namespace Api.Mappers
{
    public class DeductionMapper : IMapper<Deduction, GetDeductionDto>
    {
        public GetDeductionDto MapTo(Deduction from)
        {
            return new GetDeductionDto(from.Name, from.Value);
        }
    }
}
