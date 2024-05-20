using Application.Interfaces;
using Azure.Core;
using Core;
using Core.Entities;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RequestService : IRequestService
    {
        private readonly GrassShopDbContext dbContext;

        public RequestService(GrassShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<RequestDto> AddRequest(RequestDto model)
        {
            
            var request = new Requests
            {
                createDate = model.createDate,
                updateDate = model.updateDate,
                ip = model.IP,
                Fname = model.Fname,
                Lname = model.Lname,
                email = model.email,
                Address = model.Address,
                phone = model.phone,
                requestNumber = model.requestNumber,
                grassId = model.grassId,
                isDeleted=false
            };
            
            await dbContext.AddAsync(request);
            await dbContext.SaveChangesAsync();

            model.Id = request.Id;

            return model;
        }

        public async Task<RequestDto> GetRequestById(int id)
        {
            var request = await dbContext.Requests.FindAsync(id);
            if (request == null)
            {
                throw new Exception("Some thing unexpected happend");
            }
            if (request.isDeleted == true)
            {
                throw new Exception("Some thing unexpected happend");
            }
            var model = new RequestDto
            {
                Id = request.Id,
                createDate = request.createDate,
                updateDate = request.updateDate,
                IP = request.ip,
                Fname = request.Fname,
                Lname = request.Lname,
                email = request.email,
                Address = request.Address,
                phone = request.phone,
                requestNumber = request.requestNumber,
                grassId = request.grassId
            };
            return model;
        }

        public async Task<List<RequestDto>> GetAllRequests()
        {
            var result = await dbContext.Requests.Where(request => request.isDeleted == false).Select(request => new RequestDto
            {
                Id = request.Id,
                createDate = request.createDate,
                updateDate = request.updateDate,
                IP = request.ip,
                Fname = request.Fname,
                Lname = request.Lname,
                email = request.email,
                Address = request.Address,
                phone = request.phone,
                requestNumber = request.requestNumber,
                grassId = request.grassId
            }).ToListAsync();
            return result;
        }

        public async Task<bool> DeleteRequest(int id)
        {
            var requestToDelete = await dbContext.Requests.FindAsync(id);
            
            if (requestToDelete == null)
            {
                throw new Exception("user doesn't exist");
            }
            try
            {

            requestToDelete.isDeleted = true;
            dbContext.Entry(requestToDelete).CurrentValues.SetValues(requestToDelete);
            dbContext.SaveChanges();
            return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRequest(RequestDto model)
        {
            
            var requestEntity = await dbContext.Requests.FindAsync(model.Id);

            if (requestEntity is null)
            {
                throw new Exception("User doesn't exist in database");
            }
            try
            {

            dbContext.Entry(requestEntity).CurrentValues.SetValues(model);

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
