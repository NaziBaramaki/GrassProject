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
                IP = model.IP,
                Fname = model.Fname,
                Lname = model.Lname,
                email = model.email,
                Address = model.Address,
                phone = model.phone,
                requestNumber = model.requestNumber,
                grassId = model.grassId
            };
            
            await dbContext.AddAsync(request);
            await dbContext.SaveChangesAsync();

            model.Id = request.Id;

            return model;
        }

        public async Task<RequestDto> GetRequestById(int id)
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
            return model;
        }

        public async Task<List<RequestDto>> GetAllRequests()
        {
            var result = await dbContext.Requests.Select(request => new RequestDto
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
            }).ToListAsync();
            return result;
        }

        public void DeleteRequest(int id)
        {
            //var requestToDelete = await dbContext.Requests.FindAsync(id);
            //dbContext.Requests.Remove(requestToDelete);
            //dbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public async void UpdateRequest(RequestDto model)
        {
            var modelId = model.Id;
            var requestEntity = await dbContext.Requests.FindAsync(modelId);
                
            if (requestEntity is null)
            {
                dbContext.Requests.Add(requestEntity);
            }
            else
            {

                if (requestEntity != null)
                {
                    dbContext.Entry(requestEntity).CurrentValues.SetValues(model);
                }
            }

            dbContext.SaveChanges();
        }
    }
}
