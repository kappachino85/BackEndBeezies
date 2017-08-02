using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Domain.Tools
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string ErrorFunction { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }
        public DateTime ErrorDate { get; set; }
        public string CreatedBy { get; set; }
    }
}