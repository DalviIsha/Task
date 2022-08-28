namespace TestMS.Domain.Interface
{
    public interface IQueryRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}