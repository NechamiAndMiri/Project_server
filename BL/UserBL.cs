using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using DL;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL userDL;
        IPasswordHashHelper _passwordHashHelper;
        IConfiguration _configuration;

        public UserBL(IUserDL userDL, IPasswordHashHelper _passwordHashHelper, IConfiguration configuration)
        {
            this.userDL = userDL;
            _configuration = configuration;
        }

        public async Task<TblUser> getUser(string email, string password)
        {
            TblUser user= await userDL.getUser(email, password);
            //if (user == null) return null;
            //// authentication successful so generate jwt token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);
            return WithoutPassword(user);
             
        }

        public async Task PostUser(TblUser user)
        {
            //user.Salt = _passwordHashHelper.GenerateSalt(8);
            //user.Password = _passwordHashHelper.HashPassword(user.Password, user.Salt, 1000, 8);
            await userDL.PostUser(user);
        }

        public static TblUser WithoutPassword(TblUser user)
        {
            user.Password = null;
            return user;
        }
    }
}
