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
        NewsDto AddNewsByUsername(string username);
        List<NewsDto> GetAllNews();
        List<NewsDto> GetAllNewsById(string username);
        UsersDto GetUserByNewsId(int id);
    }
}
