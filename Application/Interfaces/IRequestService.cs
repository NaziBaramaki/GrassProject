using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRequestService
    {
        Task<RequestDto> AddRequest(RequestDto model);
        void DeleteRequest(int id);
        void UpdateRequest(RequestDto model);
        Task<List<RequestDto>> GetAllRequests();
        Task<RequestDto> GetRequestById(int id);
                
    }
}
