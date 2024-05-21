using Application.Interfaces;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var result = await usersService.GetUserByUsername(username);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await usersService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UsersDto model)
        {
            var result = await usersService.AddUser(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UsersDto model)
        {
            var result = await usersService.UpdateUser(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await usersService.DeleteUser(id);

            return Ok(result);
        }

        [HttpGet("{username,password}")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var result = await usersService.GetToken(username, password);

            return Ok(result);
        }

        [HttpGet("{RequestId}")]
        public async Task<IActionResult> GetUserByRequestInfo(int RequestId)
        {
            var result = await usersService.GetUserByRequestId(RequestId);

            return Ok(result);
        }

        [HttpGet("{newsId}")]
        public async Task<IActionResult> GetUserByNewsInfo(int newsId)
        {
            var result = await usersService.GetUserByNewsId(newsId);

            return Ok(result);
        }
        //[HttpGet]
        //[Route("GetUserRole")]
        //[Authorize(Roles = StaticUserRoles.USER)]
        //public IActionResult GetUserRole()
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("GetAdminRole")]
        //[Authorize(Roles = StaticUserRoles.ADMIN)]
        //public IActionResult GetAdminRole()
        //{ 
        //    return Ok(); 
        //}

        //[HttpGet]
        //[Route("getOwnerRole")]
        //[Authorize(Roles = StaticUserRoles.OWNER)]
        //public IActionResult GetOwnerRole()
        //{
        //    //return Ok(summeries);
        //    return Ok();
        //}
    }
}
