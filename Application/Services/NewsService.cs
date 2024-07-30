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

        public NewsService(GrassShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<NewsDto> AddNews(NewsDto model)
        {
            var news = new News
            {
                createDate = model.createDate,
                updateDate = model.updateDate,
                ip = model.IP,
                userId = model.userId,
                farsiTitle = model.farsiTitle,
                farsiDescription = model.farsiDescription,
                farsiSubTitle = model.farsiSubTitle,
                englishTitle = model.englishTitle,
                englishDescription = model.englishDescription,
                englishSubTitle = model.englishSubTitle,
                isNews = model.isNews,
                isProduct = model.isProduct,
                isProject = model.isProject,
                isImg = model.isImg,
                imgAddress = model.imgAddress,
                isDeleted = false
            };

            await dbContext.AddAsync(news);
            await dbContext.SaveChangesAsync();

            model.Id = news.Id;

            return model;

        }

        public async Task<List<NewsDto>> GetAllNewsByUserId(string userId)
        {
            var resultNews = await dbContext.News.Where(news => ((news.isDeleted == false && news.userId == userId))).Select(news => new NewsDto
            {
                createDate = news.createDate,
                updateDate = news.updateDate,
                Id = news.Id,
                userId = news.userId,
                farsiTitle = news.farsiTitle,
                farsiDescription = news.farsiDescription,
                farsiSubTitle = news.farsiSubTitle,
                englishTitle = news.englishTitle,
                englishDescription = news.englishDescription,
                englishSubTitle = news.englishSubTitle,
                isNews = news.isNews,
                isProduct = news.isProduct,
                isProject = news.isProject,
                isImg = news.isImg,
                imgAddress = news.imgAddress,

            }).ToListAsync(); ;

            return resultNews;
        }
        public async Task<bool> DeleteNews(int id)
        {
            var NewsToDelete = await dbContext.News.FirstOrDefaultAsync<News>(u => u.Id == id);

            if (NewsToDelete == null)
            {
                throw new Exception("user doesn't exist");
            }
            try
            {
            NewsToDelete.isDeleted = true;
            dbContext.Entry(NewsToDelete).CurrentValues.SetValues(NewsToDelete);
            dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<NewsDto>> GetAllNews()
        {
            var result = await dbContext.News.Where(news => news.isDeleted == false).Select(news => new NewsDto
            {
                createDate = news.createDate,
                updateDate = news.updateDate,
                Id = news.Id,
                userId = news.userId,
                farsiTitle = news.farsiTitle,
                farsiDescription = news.farsiDescription,
                farsiSubTitle = news.farsiSubTitle,
                englishTitle = news.englishTitle,
                englishDescription = news.englishDescription,
                englishSubTitle = news.englishSubTitle,
                isNews = news.isNews,
                isProduct = news.isProduct,
                isProject = news.isProject,
                isImg = news.isImg,
                imgAddress = news.imgAddress,
            }).ToListAsync();

            return result;
        }


        public async Task<NewsDto> GetNewsById(int id)
        {
            var news = await dbContext.News.FirstOrDefaultAsync<News>(u => u.Id == id && u.isDeleted == false);
            if (news == null)
            {
                throw new Exception("Some thing unexpected happend");
            }
            var model = new NewsDto
            {
                createDate = news.createDate,
                updateDate = news.updateDate,
                Id = news.Id,
                userId = news.userId,
                farsiTitle = news.farsiTitle,
                farsiDescription = news.farsiDescription,
                farsiSubTitle = news.farsiSubTitle,
                englishTitle = news.englishTitle,
                englishDescription = news.englishDescription,
                englishSubTitle = news.englishSubTitle,
                isNews = news.isNews,
                isProduct = news.isProduct,
                isProject = news.isProject,
                isImg = news.isImg,
                imgAddress = news.imgAddress,
            };
            return model;
        }

        public async Task<bool> UpdateNews(NewsDto model)
        {

            var newsEntity = await dbContext.News.FirstOrDefaultAsync<News>(u => u.Id == model.Id);

            if (newsEntity is null)
            {
                throw new Exception("User doesn't exist in database");
            }

            try
            {
            dbContext.Entry(newsEntity).CurrentValues.SetValues(model);
            dbContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
