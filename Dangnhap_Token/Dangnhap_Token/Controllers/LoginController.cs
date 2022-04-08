﻿using Dangnhap_Token.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dangnhap_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;
            if(login.UserName =="loginwithjwt" && login.Password =="123123")
            {
                user = new UserModel { UserName = "LoginWithJWT", Email = "loginwithjwt@gmail.com", Password = "123123", RoleName="Member" };
                return user;
            }
            if(login.UserName == "loginadmin" && login.Password == "123123")
            {
                user = new UserModel { UserName = "LoginWithAdminJWT", Email = "loginwithAdmin@gmail.com", Password = "123123", RoleName="Admin" };
            }return user;
        }

        public IActionResult Login(string username, string password)
        {
            UserModel login = new UserModel();
            login.UserName = username;
            login.Password = password;
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if(user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserModel userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email,userinfo.Email),
                new Claim(ClaimTypes.Role,userinfo.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience:_config["Jwt:Issuer"],
                claims,
                expires:DateTime.Now.AddMinutes(120),
                signingCredentials:credentials
                );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var username = claim[0].Value;
            return "Welcome Admin, "+ username + "You can post something here!!!";
        }
        [Authorize(Roles = "Member")]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Welcome!!! You can see post here" };
        }
    }
}
