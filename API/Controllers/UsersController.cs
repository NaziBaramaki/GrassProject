using Application.Interfaces;
using Application.Services;
using Core.Entities;
using Infrastructure.Dto;
using Infrastructure.OtherObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {


        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet()]
        [Route("GetUser")]
        //[Authorize]
        public async Task<IActionResult> getUser(string username)
        {
            var result = await usersService.GetUserByUsername(username);

            return Ok(result);
        }

        [HttpGet()]
        [Route("GetAllUsers")]
        //[Authorize]
        public async Task<IActionResult> getAllUsers()
        {
            var result = await usersService.GetAll();
            return Ok(result);
        }
        //[HttpPost()]
        //[Route("Create")]
        //public async Task<IActionResult> Create(RegisterDto model)
        //{
        //    var result = await usersService.AddUser(model);
        //    return Ok(result);
        //}

        [HttpPut()]
        [Route("UpdateUser")]
        public async Task<IActionResult> updateUser(RegisterDto model)
        {
            var result = await usersService.UpdateUser(model);
            return Ok(result);
        }

        [HttpPut()]
        [Route("DeleteUser")]
        public async Task<IActionResult> deleteUser(string? username)
        {
            
            var result = await usersService.DeleteUser(username);

            return Ok(result);
        }
            

        [HttpGet()]
        [Route("GetUserByRequestInfo")]
        public async Task<IActionResult> GetUserByRequestInfo(int RequestId)
        {
            var result = await usersService.GetUserByRequestId(RequestId);

            return Ok(result);
        }

        [HttpGet()]
        [Route("GetUserByNewsInfo")]
        public async Task<IActionResult> GetUserByNewsInfo(int newsId)
        {
            var result = await usersService.GetUserByNewsId(newsId);

            return Ok(result);
        }
       

       

    }
}
