using BL.Interface;
using BookBorrowingAPI.Helper;
using BookBorrowingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookBorrowingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserBL _userBl;
        private IConfiguration _config;

        public UserController(IUserBL userBl, IConfiguration config)
        {
            _userBl = userBl;
            _config = config;
        }


        // POST api/<UserController>
        [HttpPost]
        [Route("login/post")]
        public ActionResult<Object> Post(UserLogin val)
        {
           
                User user = new UserLoginToUserHelper().UserLoginToUserMapping(val);
                var userdummy = _userBl.IsUserValid(user);
                if (userdummy != null)
                {
                var tokenstring = GenerateToken(userdummy);
                UserModel usr = new UserToUserModelHelper().UserToUserModelMapping(userdummy);
                usr.tokenjwt = tokenstring;
               
                return Ok(usr);
            }
                else
                    return Unauthorized(null);

        }


        [Authorize]
        [HttpGet("{id}")]
        [Route("GetUserById/{id}")]
        public ActionResult GetUserById(int id)
        {
            var u = _userBl.GetUserById(id);
            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return NoContent();
            }


        }

        private string GenerateToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, userInfo.UserName),
            new Claim(ClaimTypes.GivenName, userInfo.Name),
            new Claim(ClaimTypes.UserData, userInfo.UserId.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //// GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
