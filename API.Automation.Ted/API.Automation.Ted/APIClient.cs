﻿using API.Automation.Ted.Auth;
using API.Automation.Ted.Models.Response;
using API.Automation.Ted.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Automation.Ted
{
    public class APIClient : IAPIClient, IDisposable
    {
        readonly RestClient client;
        readonly string BASE_URL="https://reqres.in/";
        public APIClient()
        {
            client = new RestClient(BASE_URL);
            //var options=new RestClientOptions(BASE_URL);
            //client = new RestClient(options)
            //{
            //    Authenticator = new APIAuthenticator()
            //};
        }
        public async Task<RestResponse> CreateUser<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_USER, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> DeleteUser<T>(string id)
        {
            var request=new RestRequest(Endpoints.DELETE_USER, Method.Delete);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> GetListOfUsers<T>(int pageNumber)
        {
            var request=new RestRequest(Endpoints.GET_LIST_OF_USERS, Method.Get);
            request.AddQueryParameter("page", pageNumber);
            var res= await client.ExecuteAsync(request);           
            return res;
        }

        public async Task<RestResponse> GetUser<T>(string id)
        {
            var request = new RestRequest(Endpoints.GET_SINGLE_USER, Method.Get);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateUser<T>(T payload, string id) where T : class
        {
            var request = new RestRequest(Endpoints.UPDATE_USER, Method.Put);
            request.AddUrlSegment(id, id);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }
    }
}
