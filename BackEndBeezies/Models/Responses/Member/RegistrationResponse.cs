using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Models.Responses.Member
{
    public class RegistrationResponse
    {
        public int MemberProfileId { get; set; }

        public string AspNetUserID { get; set; }

        public string Email { get; set; }
    }
}