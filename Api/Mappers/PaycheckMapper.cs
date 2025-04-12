using Api.Dtos.Paycheck;
using Api.Mappers.Interfaces;
using Api.Models;

namespace Api.Mappers
{
    public class PaycheckMapper : IMapper<Paycheck, GetPaycheckDto>
    {
        private readonly IMapper<Deduction, GetDeductionDto> deductionMapper;

        public PaycheckMapper(IMapper<Deduction, GetDeductionDto> deductionMapper)
        {
            this.deductionMapper = deductionMapper;
        }

        public GetPaycheckDto MapTo(Paycheck from)
        {
            return new GetPaycheckDto(
                from.EmployeeId,
                from.EmployeeFirstName,
                from.EmployeeLastName,
                from.GrossPay,
                from.NetPayPreTax,
                from.Deductions.Select(deductionMapper.MapTo).ToList(),
                from.DeductionsTotal
                );
        }
    }
}
