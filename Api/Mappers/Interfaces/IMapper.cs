namespace Api.Mappers.Interfaces
{
    public interface IMapper<TFrom, TTo>
    {
        /// <summary>
        /// TODO doc
        /// </summary>
        /// <remarks>
        /// Custom mapper implementation used not to introduce dependencies on external libraries for this exercise.
        /// </remarks>
        /// <param name="from"></param>
        /// <returns></returns>
        TTo MapTo(TFrom from);
    }
}
