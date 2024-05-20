using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INewsService
    {
        Task<NewsDto> AddNews(NewsDto model);
        Task<List<NewsDto>> GetAllNews();
        Task<NewsDto> GetNewsById(int id);
        Task<List<NewsDto>> GetAllNewsByUserId(int id);
        Task<bool> DeleteNews(int id);
        Task<bool> UpdateNews(NewsDto model);
    }
}
