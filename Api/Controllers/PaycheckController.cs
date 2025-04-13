using Api.Dtos.Employee;
using Api.Dtos.Paycheck;
using Api.Mappers;
using Api.Mappers.Interfaces;
using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        /// <summary>
        /// Get paycheck by employee id
        /// </summary>
        /// <param name="id">Id of employee</param>
        /// <returns></returns>
        /// <response code="200">Returns the paycheck</response>
        /// <response code="400">If paycheck not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
