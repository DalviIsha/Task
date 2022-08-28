using TestMS.API.Controllers;
using TestMS.Domain.Interface;

namespace TestMS.Infrastructure.Service
{
    public class UserQueryRepo : QueryRepository<RefUser>, IUserQueryRepo
    {
        public UserQueryRepo(WriteTestMSContext dbContext)
        : base(dbContext)
        {
        }
    }
}