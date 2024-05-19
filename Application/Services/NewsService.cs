using Application.Interfaces;
using Azure.Core;
using Core;
using Core.Entities;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NewsService : INewsService
    {
        private GrassShopDbContext dbContext;

        public NewsService(GrassShopDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public async Task<NewsDto> AddNews(NewsDto model)
        {
            var news = new News
            {
                createDate = model.createDate,
                updateDate = model.updateDate,
                IP = model.IP,
                Id = model.Id,
                userId = model.userId,
                Title = model.Title,
                Description = model.Description,
                langusge = model.langusge,
                isImg = model.isImg,
                picture = model.picture
            };

            await dbContext.AddAsync(news);
            await dbContext.SaveChangesAsync();

            model.Id = news.Id;

            return model;

        }

        public async Task<List<UsersDto>> GetAllNewsByUserId(int userId)
        {
            //var value = await dbContext.News
            //.Where(News => News.userId = userId.ToString())
            //.Select(News => News.Id)
            //.ToListAsync();

            // return value;
            throw new NotImplementedException();
        }
        public void DeleteNews(int id)
        {
            //var NewsToDelete = dbContext.News.FindAsync(id);
            //dbContext.News.Remove(NewsToDelete);
            //dbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public Task<NewsDto> AddNewsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NewsDto>> GetAllNews()
        {
            var result = await dbContext.News.Select(news => new NewsDto
            {
                createDate = news.createDate,
                updateDate = news.updateDate,
                IP = news.IP,
                Id = news.Id,
                userId = news.userId,
                Title = news.Title,
                Description = news.Description,
                langusge = news.langusge,
                isImg = news.isImg,
                picture = news.picture
            }).ToListAsync();       
              
            return result;
        } 
   

        public Task<List<NewsDto>> GetNewsById(string username)
        {
            throw new NotImplementedException();
        }

        public async void UpdateNews(NewsDto model)
        {

            var modelId = model.Id;
            var newsEntity = await  dbContext.News.FindAsync(modelId);
               
            if (newsEntity is null)
            {
                dbContext.News.Add(newsEntity);
            }
            else
            {

                if (newsEntity != null)
                {
                    dbContext.Entry(newsEntity).CurrentValues.SetValues(model);
                }
            }

            dbContext.SaveChanges();
        }
    }
}
