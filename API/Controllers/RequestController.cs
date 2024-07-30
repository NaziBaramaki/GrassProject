using Application.Interfaces;
using Application.Services;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpGet()]
        [Route("GetRequest")]
        public async Task<IActionResult> Get(int id)
        { 
            var result = await requestService.GetRequestById(id);
            return Ok(result);
        }

        [HttpGet()]
        [Route("GetAllRequests")]
        public async Task<IActionResult> GetAll()
        {
            var result = await requestService.GetAllRequests();
            return Ok(result);
        }

        [HttpPost()]
        [Route("CreateRequest")]
        public async Task<IActionResult> Create(RequestDto model)
        {
            var result = await requestService.AddRequest(model);
            return Ok(result);
        }

        [HttpPut()]
        [Route("UpdateRequest")]
        public async Task<IActionResult> Update(RequestDto model)
        {
            var result = await requestService.UpdateRequest(model);
            return Ok(result);
        }

        [HttpPut()]
        [Route("DeleteRequest")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await requestService.DeleteRequest(id);

            return Ok(result);
        }

    }
}
