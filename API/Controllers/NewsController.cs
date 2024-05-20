using Application.Interfaces;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await newsService.GetNewsById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await newsService.GetAllNews();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsDto model)
        {
            var result = await newsService.AddNews(model);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(NewsDto model)
        {
            var result = await newsService.UpdateNews(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await newsService.DeleteNews(id);

            return Ok(result);
        }
    }
}
