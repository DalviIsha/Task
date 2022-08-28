using Microsoft.EntityFrameworkCore;
using TestMS.Domain.Configuration;

namespace TestMS
{
    public class WriteTestMSContext : DataContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WriteTestMSContext(
            DbContextOptions<WriteTestMSContext> options)
             : base(options)
        {
        }
    }
}