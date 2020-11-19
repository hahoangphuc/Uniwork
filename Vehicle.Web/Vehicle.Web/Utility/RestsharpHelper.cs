using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Web.Areas.Admin.Models;

namespace Vehicle.Web.Utility
{
    public class RestsharpHelper 
    {
        public string CallApi(string resource, Method method,bool isHeader = false, string dataBody = null)
        {
            RestClient client = new RestClient("http://localhost:3040/"); //domain
            var request = new RestRequest(resource, method);  //api/customer/update
            request.RequestFormat = DataFormat.Json;  //type of ajax

            if (isHeader) {
                request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
            }
            
            if(method == Method.POST || method == Method.PUT)
            {                
                request.AddParameter("application/x-www-form-urlencoded", dataBody, ParameterType.RequestBody);                
            }
           
            IRestResponse response = client.Execute(request);
            string content = response.Content; //"true"     "{}"
           
            return content;
        }


    }
}