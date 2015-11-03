using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlowWebservice.Models
{
    public class ResponseModel
    {
        public static string RESPONSE_GET = "GET";
        public static string RESPONSE_POST = "POST";
        public static string RESPONSE_PUT = "PUT";
        public static string RESPONSE_DELETE = "DELETE";

        public bool succes = true;
        public int statusCode = 200;
        public string requestType { get; set; }
        public int size { get; set; }
        public List<IResponseModel> data { get; set; }

        public ResponseModel(List<IResponseModel> data, string requestType)
        {
            this.data = data;
            size = data.Count;
            this.requestType = requestType;

            if(size == 0)
            {
                statusCode = 204;
            }
        }
    }
}