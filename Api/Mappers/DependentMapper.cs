using Api.Dtos.Dependent;
using Api.Mappers.Interfaces;
using Api.Models;

namespace Api.Mappers
{
    public class DependentMapper : IMapper<Dependent, GetDependentDto>
    {
        public GetDependentDto MapTo(Dependent from)
        {
            return new GetDependentDto
            {
                DateOfBirth = from.DateOfBirth,
                FirstName = from.FirstName,
                Id = from.Id,
                LastName = from.LastName,
                Relationship = from.Relationship
            };
        }
    }
}
