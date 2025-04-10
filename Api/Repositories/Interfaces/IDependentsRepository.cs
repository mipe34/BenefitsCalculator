using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IDependentsRepository
    {
        /// <summary>
        /// Finds and dependent by theirs id
        /// </summary>
        /// <param name="id">Id of dependent</param>
        /// <returns>Dependent model if found and null otherwise</returns>
        Task<Dependent?> FindDependent(int id);

        /// <summary>
        /// Lists all dependents
        /// </summary>
        /// <returns>A collection of all dependents found</returns>
        Task<IEnumerable<Dependent>> GetAlldependents();
    }
}
