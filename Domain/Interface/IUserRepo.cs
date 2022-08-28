using TestMS.API.Controllers;

namespace TestMS.Domain.Interface
{
    public interface IUserRepo
    {
        Task<bool> CreateUser(UserDto userdetails);
        Task<bool> updateUser(UserDto userdetails);
        Task<List<RefUser>> GetUser();


    }
}