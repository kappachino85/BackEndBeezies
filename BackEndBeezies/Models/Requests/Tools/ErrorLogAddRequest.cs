using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Models.Requests.Tools
{
    public class ErrorLogAddRequest
    {
        public string ErrorFunction { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }
        public string CreatedBy { get; set; }
    }
}