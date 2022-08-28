using TestMS.API.Controllers;
using TestMS.Domain.Interface;

namespace TestMS.Domain.Interface
{
    public interface IUserQueryRepo : IQueryRepository<RefUser>
    {
    }
}