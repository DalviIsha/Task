using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestMS.API.Controllers;
using TestMS.API.Interface;
using TestMS.Domain.Interface;

namespace TestMS.API.Service
{
    public class Authentication : IAuthentication
    {
        private readonly ICustomRepo _customRepo;

        public Authentication(ICustomRepo customRepo)
        {
            _customRepo = customRepo;
        }

        private readonly string key;
        public Authentication(string key)
        {
            this.key = key;
        }

        public async Task<string> GetAuthenticationToken(string userName, string password)
        {
            List<RefUser> user = new List<RefUser>();
            if (!user.Any(x => x.UserName == userName && x.Password == password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokens = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(tokens);
        }
    }
}