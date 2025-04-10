using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Finds and employee by theirs id
        /// </summary>
        /// <param name="id">Id of employee</param>
        /// <returns>Employee model if found and null otherwise</returns>
        Task<Employee?> FindEmployee(int id);

        /// <summary>
        /// Lists all employees
        /// </summary>
        /// <returns>A collection of all employees found</returns>
        Task<IEnumerable<Employee>> GetAllEmployees();
    }
}
