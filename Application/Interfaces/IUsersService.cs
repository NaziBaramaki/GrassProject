using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task<List<UsersDto>> GetAll();
        Task<UsersDto> GetUserByUsername(string username);               
        Task<UsersDto> GetToken(string username , string password);
        Task<UsersDto> GetUserByRequestId(int id);
        Task<UsersDto> AddUser(UsersDto model);
        void DeleteUser(int id);
        void UpdateUser(UsersDto model);
        Task<UsersDto> GetUserByNewsId(int id);

    }
}
