using Application.Interfaces;
using Azure.Core;
using Core;
using Core.Entities;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly GrassShopDbContext dbContext;
        public UsersService(GrassShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UsersDto> AddUser(UsersDto model)
        {
            var user = new Users
            {
                createDate = model.createDate,
                updateDate = model.updateDate,
                IP = model.IP,
                id = model.id,
                Fname = model.Fname,
                Lname = model.Lname,
                Username = model.Username,
                password = model.password,
                email = model.email,
                Token = model.Token,
                phone = model.phone
            };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
            model.id = user.id;

            return model;

        }

        public void DeleteUser(int id)
        {
            //var userToDelete = await dbContext.user.FindAsync(id);
            //dbContext.user.Remove(userToDelete);
            //dbContext.SaveChanges();
            throw new NotImplementedException();

        }

        public async Task<List<UsersDto>> GetAll()
        {
            var result = await dbContext.user.Select(Users => new UsersDto
            {
                createDate = Users.createDate,
                updateDate = Users.updateDate,
                IP = Users.IP,
                id = Users.id,
                Fname = Users.Fname,
                Lname = Users.Lname,
                Username = Users.Username,
                password = Users.password,
                email = Users.email,
                Token = Users.Token,
                phone = Users.phone

            }).ToListAsync();
            return result;
        }

        public async Task<UsersDto> GetUserByUsername(string username)
        {
            var user = await dbContext.user.FindAsync(username);
            var model = new UsersDto
            {
                createDate = user.createDate,
                updateDate = user.updateDate,
                IP = user.IP,
                id = user.id,
                Fname = user.Fname,
                Lname = user.Lname,
                Username = user.Username,
                password = user.password,
                email = user.email,
                Token = user.Token,
                phone = user.phone
            };
            return model;
        }

        public async Task<UsersDto> GetToken(string username, string password)
        {
            var user = await dbContext.user.FindAsync(username);
            if (user.password == password)
            {

                var model = new UsersDto
                {
                    createDate = user.createDate,
                    updateDate = user.updateDate,
                    IP = user.IP,
                    id = user.id,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Username = user.Username,
                    password = user.password,
                    email = user.email,
                    Token = user.Token,
                    phone = user.phone
                };
                return model;
            }
            else
            {
                return null;
            }

        }

        public async Task<UsersDto> GetUserByRequestId(int id)
        {
            var request = await dbContext.Requests.FindAsync(id);
            var model = new RequestDto
            {
                Id = request.Id,
                createDate = request.createDate,
                updateDate = request.updateDate,
                IP = request.IP,
                Fname = request.Fname,
                Lname = request.Lname,
                email = request.email,
                Address = request.Address,
                phone = request.phone,
                requestNumber = request.requestNumber,
                grassId = request.grassId
            };
            string email = model.email;
            var user = await dbContext.user.FindAsync(email);
            if (user != null)
            {
                throw new Exception("Some thing unexpected happend");
            }
            else
            {

                var userModel = new UsersDto
                {
                    createDate = user.createDate,
                    updateDate = user.updateDate,
                    IP = user.IP,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Username = user.Username,
                    password = user.password,
                    email = user.email,
                    phone = user.phone,
                };

                return userModel;
            }
        }

        public async void UpdateUser(UsersDto model)
        {
            var modelId = model.id;
            var userEntity = await dbContext.user.FindAsync(modelId);

            if (userEntity is null)
            {
                dbContext.user.Add(userEntity);
            }
            else
            {

                if (userEntity != null)
                {
                    dbContext.Entry(userEntity).CurrentValues.SetValues(model);
                }
            }

            dbContext.SaveChanges();

        }

        public async Task<UsersDto> GetUserByNewsId(int id)
        {
            var News = await dbContext.News.FindAsync(id);

            if (News == null)
            {
                throw new Exception("Some thing unexpected happend");
            }
            else
            {

                var model = new NewsDto
                {                    
                    createDate = News.createDate,
                    updateDate = News.updateDate,
                    IP = News.IP,
                    Id = News.Id,
                    userId = News.userId,
                    Title = News.Title,
                    Description = News.Description,
                    langusge = News.langusge,
                    isImg = News.isImg,
                    picture = News.picture

                };
                string userId = model.userId;
                var user = await dbContext.user.FindAsync(userId);

                if (user != null)
                {
                    throw new Exception("Some thing unexpected happend");
                }
                else
                {

                    var userModel = new UsersDto
                    {
                        createDate = user.createDate,
                        updateDate = user.updateDate,
                        IP = user.IP,
                        Fname = user.Fname,
                        Lname = user.Lname,
                        Username = user.Username,
                        password = user.password,
                        email = user.email,
                        phone = user.phone,
                    };

                    return userModel;
                }
            }
        }
    }
}
