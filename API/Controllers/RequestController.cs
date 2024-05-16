using Application.Interfaces;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        { 
            var result = await requestService.GetRequestById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await requestService.GetAllRequests();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequestDto model)
        {
            var result = await requestService.AddRequest(model);
            return Ok(result);
        }


    }
}
