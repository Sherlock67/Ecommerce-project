using Microsoft.EntityFrameworkCore;
using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext db;
        public AuthRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Customer> Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var user = await db.Customers.FirstOrDefaultAsync(x => x.UserName == username);
                if (user != null)
                {
                    if (VerifyPassword(password, user.PasswordSalt, user.PasswordHash))
                    {
                        return user;
                    }
                }
            }
            return null;
        }
        private bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public Task<Customer> RegisterUser(Customer customer, string password)
        {
            throw new NotImplementedException();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            if (await db.Customers.AnyAsync(x => x.UserName == username))
            {
                return true;
            }
            return false;
        }
    }
}
