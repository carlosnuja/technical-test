using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.ApiClient
{
    public abstract class ClientBase
    {
        protected readonly IApiClient ApiClient;

        protected ClientBase(IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        // Other methods removed for brevity

        protected static async Task<tresponse>
        CreateJsonResponse<tresponse>(HttpResponseMessage response) where TResponse : ApiResponse, new()
        {
            var clientResponse = new TResponse
            {
                StatusIsSuccessful = response.IsSuccessStatusCode,
                ErrorState = response.IsSuccessStatusCode ?
                null : await DecodeContent<errorstateresponse>(response),
                ResponseCode = response.StatusCode
            };
            if (response.Content != null)
            {
                clientResponse.ResponseResult = await response.Content.ReadAsStringAsync();
            }

            return clientResponse;
        }
    }
}