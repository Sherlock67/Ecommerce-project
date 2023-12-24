using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using pandacommerce_dal.StaticInfos;
using pandacommerce_dal.ViewModels.Logins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pandacommerce_dal.Repository
{
    public class LoginRepository : ILoginRepository

    {
        private readonly ApplicationDbContext db;
        
        public LoginRepository(ApplicationDbContext db)
        {
            this.db = db;
    
        }

        public Task<AppUser> Create(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public vmLogin UserLogin(string username, string password)
        {
            vmLogin login = new vmLogin();
            var logins = db.AppUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if(logins != null)
            {
                login.Key =  GenerateJSONWebToken(logins, 90);
            }
            return login;
        }
        private string GenerateJSONWebToken(AppUser userInfo, int ExpireIn)
        {

            //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticInfo.JwtKey));
            //SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Claim[] claims = new[]
            // {
            //    new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(), ClaimValueTypes.Integer64),
            //    new Claim(JwtRegisteredClaimNames.Email, userInfo.Email, ClaimValueTypes.String),
            //    //new Claim("ipaddress", userInfo.RemoteIpAddress, ClaimValueTypes.String),
            //    //new Claim("machinename", userInfo.MachineName, ClaimValueTypes.String),
            //    new Claim("userId", Convert.ToString(userInfo.UserId), ClaimValueTypes.String),
            //    //new Claim("roleId", Convert.ToString(userInfo.RoleID), ClaimValueTypes.String)
            //};

            //// Create the JWT and write it to a string
            //JwtSecurityToken jwt = new JwtSecurityToken(
            //    issuer: StaticInfo.JwtIssuer,
            //    audience: StaticInfo.JwtAudience,
            //    claims: claims,
            //    notBefore: DateTime.UtcNow,
            //    expires: DateTime.UtcNow.AddMinutes(ExpireIn),//This token will expire after 45 minutes
            //    signingCredentials: credentials);

            //return new JwtSecurityTokenHandler().WriteToken(jwt);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticInfo.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
             {
                new Claim("AdminOnly", "Admin"),


            };


            var token = new JwtSecurityToken(StaticInfo.JwtIssuer,
                StaticInfo.JwtAudience,
                claims : claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
