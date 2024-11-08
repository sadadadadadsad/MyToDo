using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Shared;
using Newtonsoft.Json;
namespace MyToDO.Service
{
    public class HttpRestClient
    {
        private readonly string apiUri;
        protected readonly RestClient client;
        public HttpRestClient(string apiUri)
        {
            this.apiUri = apiUri;
            client = new RestClient(apiUri);
        }
        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(apiUri+baseRequest.Route,baseRequest.Method); //创建请求
            request.AddHeader("Content-Type",baseRequest.ContentType);  
            if(baseRequest.Parameter!= null) {
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
                client.Options.BaseUrl = new Uri(apiUri + baseRequest.Route);

        }
    }

}
