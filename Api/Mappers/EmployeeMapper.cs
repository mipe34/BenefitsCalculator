using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Mappers.Interfaces;
using Api.Models;

namespace Api.Mappers
{
    public class EmployeeMapper : IMapper<Employee, GetEmployeeDto>
    {
        private readonly IMapper<Dependent, GetDependentDto> dependentMapper;

        public EmployeeMapper(IMapper<Dependent, GetDependentDto> dependentMapper)
        {
            this.dependentMapper = dependentMapper;
        }

        public GetEmployeeDto MapTo(Employee from)
        {
            return new GetEmployeeDto()
            {
                DateOfBirth = from.DateOfBirth,
                Dependents = from.Dependents.Select(x => dependentMapper.MapTo(x)).ToArray(),
                FirstName = from.FirstName,
                Id = from.Id,
                LastName = from.LastName,
                Salary = from.Salary
            };
        }
    }
}
