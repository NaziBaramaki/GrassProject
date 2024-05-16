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
        List<UsersDto> GetAll();
        UsersDto Get(string username);
        UsersDto GetById(int id);        
    }
}
