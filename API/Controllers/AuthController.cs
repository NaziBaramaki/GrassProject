﻿using Application.Interfaces;
using Application.Services;
using Core.Entities;
using Infrastructure.Dto;
using Infrastructure.OtherObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            bool isOwnerRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.OWNER);
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.ADMIN);
            bool isCustomerRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.CUSTOMER);

            if (isOwnerRoleExists && isAdminRoleExists && isCustomerRoleExists)
                return Ok("Roles Seeding is Already Done");

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.CUSTOMER));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.ADMIN));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.OWNER));

            return Ok("Role Seeding Done Successfully");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var isExistsUser = await _userManager.FindByNameAsync(registerDto.UserName);

            if (isExistsUser != null)
                return BadRequest("UserName Already Exists");

            Users newUser = new Users()
            {
                createDate = registerDto.createDate,
                updateDate = registerDto.updateDate,
                ip = registerDto.IP,
                Fname = registerDto.Fname,
                Lname = registerDto.Lname,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            await _userManager.AddToRoleAsync(newUser, StaticUserRoles.CUSTOMER);

            if (!createUserResult.Succeeded)
            {
                var errorString = "User Creation Failed Beacause: ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return BadRequest(errorString);
            }

            // Add a Default USER Role to all users
            await _userManager.AddToRoleAsync(newUser, StaticUserRoles.CUSTOMER);

            return Ok("User Created Successfully");
        }


        // Route -> Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is null)
                return Unauthorized("Invalid Credentials");

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
                return Unauthorized("Invalid Credentials");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FirstName",user.Fname),
                new Claim("LastName", user.Lname),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GenerateNewJsonWebToken(authClaims);

            return Ok(token);
        }

        private string GenerateNewJsonWebToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenObject = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }

        [HttpGet()]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user is null)
                return Unauthorized("Invalid Credentials");

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordCorrect)
                return Unauthorized("Invalid Credentials");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FirstName",user.Fname),
                new Claim("LastName", user.Lname),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GenerateNewJsonWebToken(authClaims);

            return Ok(token);
        }

        // Route -> make user -> admin
        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string username, string password, string newPassword)
        {

            var user = await _userManager.FindByNameAsync(username);

            if (user is null)
                return Unauthorized("Invalid Credentials");

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordCorrect)
                return Unauthorized("Invalid Credentials");

            var result = await _userManager.ChangePasswordAsync(user, password, newPassword).ConfigureAwait(false);          

            return Ok();
        }


        // Route -> make user -> admin
        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

            if (user is null)
                return BadRequest("Invalid User name");

            await _userManager.RemoveFromRoleAsync(user, StaticUserRoles.CUSTOMER);
            await _userManager.AddToRoleAsync(user, StaticUserRoles.ADMIN);

            return Ok("User is now an ADMIN");
        }

        // Route -> make user -> owner
        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

            if (user is null)
                return BadRequest("Invalid User name");
            await _userManager.RemoveFromRoleAsync(user, StaticUserRoles.CUSTOMER);
            await _userManager.AddToRoleAsync(user, StaticUserRoles.OWNER);

            return Ok("User is now an Owner");
        }

        [HttpGet()]
        [Route("GetUsersRole")]
        //[Authorize(Roles = StaticUserRoles.CUSTOMER)]
        public async Task<IActionResult> GetUserRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userRoles = await _userManager.GetRolesAsync(user);
            return Ok(userRoles);
        }

        [HttpGet()]
        [Route("GetAdminsRole")]
        //[Authorize(Roles = StaticUserRoles.ADMIN)]
        public async Task<IActionResult> GetAdminsUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync(StaticUserRoles.ADMIN);
            return Ok(users);
        }

        [HttpGet()]
        [Route("GetOwnersRole")]
        //[Authorize(Roles = StaticUserRoles.OWNER)]
        public async Task<IActionResult> GetOwnersUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync(StaticUserRoles.OWNER);
            return Ok(users);
        }

    }
}
