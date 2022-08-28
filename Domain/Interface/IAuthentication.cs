using TestMS.API.Controllers;

namespace TestMS.Domain.Interface
{
    public interface IAuthentication
    {
        Task<string> GetAuthenticationToken(string userName, string password);
    }
}