using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Domain.Member
{
    public class MemberProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string AspNetUserId { get; set; }
    }
}