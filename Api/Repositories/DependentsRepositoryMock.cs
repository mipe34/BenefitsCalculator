using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Repositories
{
    /// <summary>
    /// The real implementation would suppose to read employees from some persistence layer (eg.database)
    /// In this mock the dependants are read using the employees repository to keep one source of data.
    /// </summary>
    public class DependentsRepositoryMock : IDependentsRepository
    {
        private readonly IEmployeesRepository employeesRepository;

        public DependentsRepositoryMock(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public async Task<Dependent?> FindDependent(int id)
        {
            var allDependents = await GetAlldependents();
            return allDependents.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Dependent>> GetAlldependents()
        {
            var allEmployees = await employeesRepository.GetAllEmployees();
            return allEmployees.SelectMany(x => x.Dependents);
        }
    }
}
