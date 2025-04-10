using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Mappers;
using Api.Mappers.Interfaces;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    private readonly IDependentsRepository dependentsRepository;
    private readonly IMapper<Dependent, GetDependentDto> dependentMapper;

    public DependentsController(IDependentsRepository dependentsRepository, IMapper<Dependent, GetDependentDto> dependentMapper)
    {
        this.dependentsRepository = dependentsRepository;
        this.dependentMapper = dependentMapper;
    }

    // TODO: swagger doc
    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id)
    {
        var dependentModel = await dependentsRepository.FindDependent(id);
        if(dependentModel == null)
        {
            return NotFound(new ApiResponse<GetDependentDto>()
            {
                Message = "Dependent not found" // TODO localization
            });
        }
        var result = new ApiResponse<GetDependentDto>()
        {
            Data = dependentMapper.MapTo(dependentModel),
            Success = true
        };
        return result;
    }

    // TODO: swagger doc
    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
    {
        var dependentModels = await dependentsRepository.GetAlldependents();
        var dependents = dependentModels.Select(dependentMapper.MapTo).ToList();

        var result = new ApiResponse<List<GetDependentDto>>
        {
            Data = dependents,
            Success = true
        };
        return result;
    }
}
