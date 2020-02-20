using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineBookShop.API.Configuration;
using OnlineBookShop.API.Dtos.Account;

namespace OnlineBookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly AuthOptions _authenticationOptions;
        public AccountController(IOptions<AuthOptions> authenticationOptions)
        {
            _authenticationOptions = authenticationOptions.Value;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            if (userForLoginDto.Username == "admin" && userForLoginDto.Password == "Qwerty")
            {
                var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: _authenticationOptions.Issuer,
                     audience: _authenticationOptions.Audience,
                     claims: new List<Claim>(),
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: signinCredentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                return Ok(new { AccessToken = encodedToken });
            }

            return Unauthorized();
        }
    }
}