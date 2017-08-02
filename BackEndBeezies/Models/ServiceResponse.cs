using BackEndBeezies.Web.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Web.Models
{
    public class ServiceResponse : BaseResponse
    {
        public string ResponseMessage { get; set; }
    }
}