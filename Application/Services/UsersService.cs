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
       
        public async Task<RegisterDto> AddUser(RegisterDto model)
        {
            var user = new Users
            {
                createDate = model.createDate,
                updateDate = model.updateDate,
                ip = model.IP,
                Fname = model.Fname,
                Lname = model.Lname,
                UserName = model.UserName,
                PasswordHash = model.Password,
                Email = model.Email,
                PhoneNumber = model.phone,
                isDeleted = false
            };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
            model.UserName = user.UserName;

            return model;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await dbContext.user.FindAsync(id);
            //dbContext.user.Remove(userToDelete);
            if (userToDelete == null)
            {
                throw new Exception("user doesn't exist");
            }
            try
            {
            userToDelete.isDeleted = true;
            dbContext.Entry(userToDelete).CurrentValues.SetValues(userToDelete);
            dbContext.SaveChanges();
            return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RegisterDto>> GetAll()
        {
            var result = await dbContext.user.Where(users => users.isDeleted==false).Select(users => new RegisterDto
            {
                createDate = users.createDate,
                updateDate = users.updateDate,
                IP = users.ip,                
                Fname = users.Fname,
                Lname = users.Lname,
                UserName = users.UserName,
                Password = users.PasswordHash,
                Email = users.Email,
                phone = users.PhoneNumber

            }).ToListAsync();
            return result;
        }

        public async Task<RegisterDto> GetUserByUsername(string username)
        {
            var user = await dbContext.user.FindAsync(username);
            if (user.isDeleted == true)
            {
                throw new Exception("Some thing unexpected happend");
            }
            var model = new RegisterDto
            {
                createDate = user.createDate,
                updateDate = user.updateDate,
                IP = user.ip,
                Fname = user.Fname,
                Lname = user.Lname,
                UserName = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email,
                phone = user.PhoneNumber
            };
            return model;
        }

        public async Task<RegisterDto> GetToken(string username, string password)
        {
            var user = await dbContext.user.FindAsync(username);
            if (user.isDeleted == true)
            {
                throw new Exception("Some thing unexpected happend");
            }
            if (user.PasswordHash == password)
            {
                var model = new RegisterDto
                {
                    createDate = user.createDate,
                    updateDate = user.updateDate,
                    IP = user.ip,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    UserName = user.UserName,
                    Password = user.PasswordHash,
                    Email = user.Email,
                    phone = user.PhoneNumber
                };
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<RegisterDto> GetUserByRequestId(int id)
        {
            var request = await dbContext.Requests.FindAsync(id);
            if (request.isDeleted == true)
            {
                throw new Exception("Some thing unexpected happend");
            }
            string email = request.email;
            var user = await dbContext.user.FindAsync(email);
            if (user == null)
            {
                throw new Exception("Some thing unexpected happend");
            }
            else
            {
                if (user.isDeleted == true)
                {
                    throw new Exception("Some thing unexpected happend");
                }

                var userModel = new RegisterDto
                {
                    createDate = user.createDate,
                    updateDate = user.updateDate,
                    IP = user.ip,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    UserName = user.UserName,
                    Password = user.PasswordHash,
                    Email = user.Email,
                    phone = user.PhoneNumber
                };

                return userModel;
            }
        }

        public async Task<bool> UpdateUser(RegisterDto model)
        {
            var userEntity = await dbContext.user.FindAsync(model.UserName);

            if (userEntity is null)
            {
                throw new Exception("User doesn't exist in database");
            }
            try
            {

            dbContext.Entry(userEntity).CurrentValues.SetValues(model);                
       
            dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }     

        }

        public async Task<RegisterDto> GetUserByNewsId(int id)
        {
            var News = await dbContext.News.FindAsync(id);
            
            if (News == null)
            {
                throw new Exception("Some thing unexpected happend");
            }
            else
            {
                if (News.isDeleted == true)
                {
                    throw new Exception("Some thing unexpected happend");
                }

                var userId = News.userId;
                var user = await dbContext.user.FindAsync(userId);

                if (user != null)
                {
                    throw new Exception("Some thing unexpected happend");
                }
                else
                {
                    if (user.isDeleted == true)
                    {
                        throw new Exception("Some thing unexpected happend");
                    }

                    var userModel = new RegisterDto
                    {
                        createDate = user.createDate,
                        updateDate = user.updateDate,
                        IP = user.ip,
                        Fname = user.Fname,
                        Lname = user.Lname,
                        UserName = user.UserName,
                        Password = user.PasswordHash,
                        Email = user.Email,
                        phone = user.PhoneNumber
                    };

                    return userModel;
                }
            }
        }
    }
}
