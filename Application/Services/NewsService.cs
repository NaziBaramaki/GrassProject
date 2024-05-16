using Application.Interfaces;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NewsService : INewsService
    {
        public NewsDto AddNewsByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<NewsDto> GetAllNews()
        {
            throw new NotImplementedException();
        }

        public List<NewsDto> GetAllNewsById(string username)
        {
            throw new NotImplementedException();
        }

        public UsersDto GetUserByNewsId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
