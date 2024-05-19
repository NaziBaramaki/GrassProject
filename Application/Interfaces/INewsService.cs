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
        Task<NewsDto> AddNewsByUserId(int userId);
        Task<List<NewsDto>> GetAllNews();
        Task<List<NewsDto>> GetNewsById(string username);
        Task<List<UsersDto>> GetAllNewsByUserId(int id);
        Task<NewsDto> AddNews(NewsDto model);
        void DeleteNews(int id);
        void UpdateNews(NewsDto model);
    }
}
