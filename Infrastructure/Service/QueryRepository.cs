using Microsoft.EntityFrameworkCore;
using TestMS;
using TestMS.Domain.Interface;

namespace TestMS.Infrastructure.Service
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity>
        where TEntity : class
    {
        protected WriteTestMSContext Context { get; }

        public QueryRepository(WriteTestMSContext context)
        {
            Context = context;
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}