using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebshopAuth.Data;
using WebshopAuth.Models;
using WebshopAuth.Models.Dtos;
using WebshopAuth.Services;

namespace WebshopAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _service;
        TokenController TC = new TokenController();
        public AccountController(IAccount _service)
        {
            this._service = _service;
        }

        [Route("/[controller]/login")]
        [HttpPost]
        public string login([FromHeader] string Authorization, [FromBody] User u)
        {
            string validToken = "";

            //check if exists
            var user = _service.login(u);

            string json = JsonConvert.SerializeObject(user);

            if (json == "null")
            {
                return "Niet gevonden";
            }
            else
            {
                if (user == null)
                {
                    return null;
                }

                UserDTO uDTO = new UserDTO();
                //wel gevonden valideren
                if(Authorization == null)
                {
                    Authorization = "Invalid";
                }

                if (TC.isExpired(Authorization))
                {
                    //als token niet valid is
                    //redirect naar login
                    validToken = loginNoToken(user.userId, user.role);
                    uDTO.user = user;
                    uDTO.token = validToken;
                    return JsonConvert.SerializeObject(uDTO);
                }
                else
                {
                    //Als token wel valid is log meteen in
                    uDTO.user = user;
                    uDTO.token = Authorization;
                    return JsonConvert.SerializeObject(uDTO);
                }
            }
        }
        public string loginNoToken(int id, int role)
        {
            string validToken = TC.nonExistentToken(id, role);

            return validToken;
        }

        [Route("/[controller]/register")]
        [HttpPost]
        public bool register([FromBody] User u)
        {
            if (u.email == "" || u.firstName == "" || u.lastName == "" || u.adress == "" || u.housenumber == "" || u.password == "" ||
                u.email == null || u.firstName == null || u.lastName == null || u.adress == null || u.housenumber == null || u.password == null)
            {
                return false;
            }
            else
            {
                var user = _service.checkRegistered(u);

                if (user == null)
                {
                    try
                    {
                        return _service.register(u);
                        
                        //redirect naar login page.
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        [Authorize]
        [HttpGet]
        [Route("/[controller]/getUser")]
        public User getUser([FromHeader] string Authorization)
        {
            string userId = "0";
            List<Claim> x = new List<Claim>();
            //list met claims
            try
            {
                x = TC.readOut(Authorization);
            }
            catch
            {
                return null;
            }

            foreach(Claim c in x)
            {
                if(c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            if(userId == "0")
            {
                return null;
            }
            else
            {
                User user = _service.getUserById(userId);
                return user;
            }
            
        }

        [Authorize]
        [HttpPut]
        [Route("/[controller]/changePassword")]
        public bool changePassword([FromHeader] string Authorization, [FromBody] ChangePassword CP)
        {
            string userId = "";
            List<Claim> claims = TC.readOut(Authorization);
            foreach (Claim c in claims)
            {
                if (c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            User u = _service.getUserById(userId);
            if(u.password == CP.oldPW && CP.newPW == CP.confirmPW)
            {
                _service.updatePassword(userId, CP.newPW);
                return true;
            }
            return false;
        }
    }
}
