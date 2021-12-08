using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebshopAuth.Controllers
{
    public class TokenController : Controller
    {
        private const string SECRET_KEY = "this is my custom Secret key for authnetication";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenController.SECRET_KEY));

        public object CreateToken(int id, int role)
        {
            if (id != 0)
            {
                return new ObjectResult(GenerateToken(id, role));
            }
            else
            {
                return new BadRequestResult();
            }
        }

        private object GenerateToken(int id, int role)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim("userId", Convert.ToString(id)),
                    new Claim(ClaimTypes.Role, role.ToString())
                },
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public List<Claim> readOut(string test)
        {
            string[] tokentemp = test.Split(" ");
            List<Claim> data = new List<Claim>();

            var token = tokentemp[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            foreach (Claim c in jwtSecurityToken.Claims)
            {
                data.Add(c);
            }
            return data;
        }

        [Authorize]
        public bool isExpired(string test)
        {

            try
            {
                string[] split = test.Split(" ");

                var token = split[1];
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                    handler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                return false;
            }
            catch
            {
                return true;
            }
        }

        public string nonExistentToken(int id, int role)
        {
            var x = GenerateToken(id, role);
            return x.ToString();
        }
    }
}
