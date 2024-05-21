using Application.Interfaces;
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
        [Route("Get")]
        [Authorize]
        public async Task<IActionResult> Get(string username)
        {
            var result = await usersService.GetUserByUsername(username);

            return Ok(result);
        }

        [HttpGet()]
        [Route("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await usersService.GetAll();
            return Ok(result);
        }
        [HttpPost()]
        [Route("Create")]
        public async Task<IActionResult> Create(RegisterDto model)
        {
            var result = await usersService.AddUser(model);
            return Ok(result);
        }

        [HttpPut()]
        [Route("Update")]
        public async Task<IActionResult> Update(RegisterDto model)
        {
            var result = await usersService.UpdateUser(model);
            return Ok(result);
        }

        [HttpPut()]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await usersService.DeleteUser(id);

            return Ok(result);
        }

        [HttpGet()]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var result = await usersService.GetToken(username, password);

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


        [HttpGet()]
        [Route("GetUsersRole")]
        [Authorize(Roles = StaticUserRoles.CUSTOMER)]
        public async Task<IActionResult> GetUsersRole(string username)
        {
            return Ok();
        }

        [HttpGet()]
        [Route("GetAdminsRole")]
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        public async Task<IActionResult> GetAdminsRole(string username)
        {
            return Ok();
        }

        [HttpGet()]
        [Route("GetOwnersRole")]
        [Authorize(Roles = StaticUserRoles.OWNER)]
        public async Task<IActionResult> GetOwnersRole(string username)
        {
            return Ok();
        }

    }
}
