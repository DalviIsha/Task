using Habanero.Base.DataMappers;
using Realms.Sync.Exceptions;
using TestMS.API.Controllers;
using TestMS.API.Interface;
using TestMS.Domain.Interface;

namespace TestMS.Infrastructure.Service
{
    public class UserRepo : IUserRepo
    {
        private readonly ICustomRepo _customRepo;
        private readonly IUserQueryRepo _IUserQueryRepo;

        public UserRepo(ICustomRepo customRepo, IUserQueryRepo iUserQueryRepo)
        {
            _customRepo = customRepo;
            _IUserQueryRepo = iUserQueryRepo;
        }

        public async Task<bool> CreateUser(UserDto userdetails)
        {
           try
           {
            bool success;
            if(userdetails is { })
            {
                var userId = Guid.NewGuid();
                success = await InsertUser(
                    userId,
                    userdetails);
            if (success)
            {
                return await _customRepo.CommitTransactionAsync();
            }
            }
            return false;
           }
           catch (AppException ex)
           {
                throw;
           }
        }
        private async Task<bool> InsertUser(Guid userId, UserDto userdetails)
        {
            RefUser user = new RefUser();
            userId = userdetails.UserId;
            user.UserName = userdetails.UserName;
            user.Password = userdetails.Password;
            user.Country = userdetails.Country;
            user.EmailId = userdetails.EmailId;
            user.CreatedTS = DateTime.UtcNow;
            return await _customRepo.CreateVendorAsync(user);
        }
        public async Task<bool> updateUser(UserDto userdetails)
        {
            try
           {
            bool success;
            if(userdetails is { })
            {
                success = await UpdateUser(
                    userdetails);
            if (success)
            {
                return await _customRepo.CommitTransactionAsync();
            }
            }
            return false;
           }
           catch (AppException ex)
           {
                throw;
           }
        }
        private async Task<bool> UpdateUser(UserDto userdetails)
        {
            Guid userId = userdetails.UserId;
            var user = _customRepo.GetUser(userId);
            var updateuser = DataMapper.Map(userdetails,
                                            user,
                                            MapperConfig.DefaultConfig);
            return await _customRepo.UpdateVendorAsync(updateuser);
        }

        public async Task<List<RefUser>> GetUser()
        {
            var user = (await _IUserQueryRepo.GetAllAsync()).OrderByDescending(x => x.CreatedTS).ToList();
            return user;
        }
    }
}