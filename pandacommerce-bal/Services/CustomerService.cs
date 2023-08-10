using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_bal.Services
{
    public class CustomerService
    {
        public readonly IAuthRepository auth;
        private readonly IConfiguration _config;
        public readonly ICustomer customer;
        public CustomerService(IAuthRepository auth, ICustomer customer, IConfiguration _config)
        {
            this.auth = auth;
            this.customer = customer;
            this._config = _config;
        }

        public async Task<Customer> RegisterCustomer(Customer customer,string password)
        {
           var username = customer.UserName;
            username = username.ToLower();

            var userToCreate = new Customer
            {
                UserName = username,
            };
            var createdUser = await auth.RegisterUser(customer,password);
            return createdUser;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            try
            {
                return customer.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<object> Login(Customer customer)
        {
            try
            {
                var userfromRepo = await auth.Login(customer.UserName, customer.Password);
                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, userfromRepo.CustomerId.ToString()),
                    new Claim(ClaimTypes.Name, userfromRepo.CustomerName)
                }; 
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Appsettings:Token").Value));

                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(120),
                    SigningCredentials = signingCredentials
                };
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                var authToken = new
                {
                    Token = tokenString
                };
                return authToken;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        //public async Task DeleteNavigationCategory(int id)
        //{

        //    try
        //    {
        //        var cat = customer.GetById(id);
        //        customer.Delete(cat);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        public async Task UpdateCustomerInformation(Customer obj)
        {
            try
            {
                customer.Update(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
