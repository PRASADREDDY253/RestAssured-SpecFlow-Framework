using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace API.Automation.Ted
{
    public interface IAPIClient
    {
        Task<RestResponse> CreateUser<T>(T payload) where T:class;
        Task<RestResponse> UpdateUser<T>(T payload, string id) where T : class;
        Task<RestResponse> DeleteUser<T>(string id);
        Task<RestResponse> GetUser<T>(string id);
        Task<RestResponse> GetListOfUser<T>(int pageNumber);
    }
}
