using TestMS.API.Controllers;
using TestMS.API.Interface;
using Microsoft.EntityFrameworkCore;
namespace TestMS.Infrastructure.Service
{
    public class CustomRepo : ICustomRepo
    {
        private readonly WriteTestMSContext _writeDbContext;

        public CustomRepo(
            WriteTestMSContext writeDbContext) => _writeDbContext = writeDbContext;

        public Task<bool> CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

       public async Task<bool> CreateVendorAsync(RefUser user)
        {
            await _writeDbContext.AddAsync(user);
            return true;
        }

        public async Task<RefUser> GetUser(Guid userId)
        {
            return await _writeDbContext.RefUser.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<bool> UpdateVendorAsync(RefUser user)
        {
            _writeDbContext.Entry(user).State = EntityState.Modified;
            return true;
        }
    }
}