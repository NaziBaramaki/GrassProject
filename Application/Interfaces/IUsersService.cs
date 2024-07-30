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
        Task<List<RegisterDto>> GetAll();
        Task<RegisterDto> GetUserByUsername(string username); 
        Task<RegisterDto> GetUserByRequestId(int id);
        Task<RegisterDto> AddUser(RegisterDto model);
        Task<bool> DeleteUser(string username);
        Task<bool> UpdateUser(RegisterDto model);
        Task<RegisterDto> GetUserByNewsId(int id);

    }
}
