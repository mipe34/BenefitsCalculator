using Api.Dtos.Employee;
using Api.Mappers.Interfaces;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesRepository employeesRepository;
    private readonly IMapper<Employee, GetEmployeeDto> employeeMapper;

    public EmployeesController(IEmployeesRepository employeesRepository, IMapper<Employee, GetEmployeeDto> employeeMapper)
    {
        this.employeesRepository = employeesRepository;
        this.employeeMapper = employeeMapper;
    }

    // TODO swager doc
    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        var employeeModel = await employeesRepository.FindEmployee(id);
        if(employeeModel is null)
        {
            return NotFound(new ApiResponse<GetEmployeeDto>
            {
                Success = false,
                Message = "Employee not found" // TODO localize
            });
        }
        var result = new ApiResponse<GetEmployeeDto>()
        {
            Data = employeeMapper.MapTo(employeeModel),
            Success = true
        };
        return result;
    }

    // TODO swager doc
    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        var employeeModels = await employeesRepository.GetAllEmployees();
        var employees = employeeModels.Select(employeeMapper.MapTo).ToList();
       
        var result = new ApiResponse<List<GetEmployeeDto>>
        {
            Data = employees,
            Success = true
        };
        return result;
    }
}
