using Api.Dtos.Employee;
using Api.Dtos.Paycheck;
using Api.Mappers;
using Api.Mappers.Interfaces;
using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaycheckController : ControllerBase
    {

        private readonly IEmployeesRepository employeesRepository;
        private readonly IMapper<Paycheck, GetPaycheckDto> paycheckMapper;
        private readonly IPaycheckService paycheckService;

        public PaycheckController(
            IEmployeesRepository employeesRepository, 
            IMapper<Paycheck, GetPaycheckDto> paycheckMapper,
            IPaycheckService paycheckService)
        {
            this.employeesRepository = employeesRepository;
            this.paycheckMapper = paycheckMapper;
            this.paycheckService = paycheckService;
        }

        // TODO swager doc
        [SwaggerOperation(Summary = "Get employee by id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<GetPaycheckDto>>> Get(int id)
        {
            // for simplicity of this exercise use a static issue date
            var paycheckModel = await paycheckService.GetPaycheck(id, new DateTime(2025, 04, 12));
            if (paycheckModel is null)
            {
                return NotFound(new ApiResponse<GetEmployeeDto>
                {
                    Success = false,
                    Message = "Paycheck not found" // TODO localize
                });
            }

            var result = new ApiResponse<GetPaycheckDto>()
            {
                Data = paycheckMapper.MapTo(paycheckModel),
                Success = true
            };
            return result;
        }
    }
}
