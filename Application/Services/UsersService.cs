using Application.Interfaces;
using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        public List<UsersDto> GetAll()
        {
            throw new NotImplementedException();
        }
      
        public UsersDto Get(string username)
        {
            throw new NotImplementedException();
        }

        public UsersDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
