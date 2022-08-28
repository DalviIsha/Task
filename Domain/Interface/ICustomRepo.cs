using TestMS.API.Controllers;

namespace TestMS.API.Interface
{
    public interface ICustomRepo
    {
        Task<bool> CommitTransactionAsync();
        Task<bool> CreateVendorAsync(RefUser user);
        Task<bool> UpdateVendorAsync(RefUser user);
        Task<RefUser> GetUser(Guid userId);
    }
}