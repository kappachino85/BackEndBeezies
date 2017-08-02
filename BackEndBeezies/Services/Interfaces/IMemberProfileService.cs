using BackEndBeezies.Models.Requests.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBeezies.Web.Services.Interfaces
{
    public interface IMemberProfileService
    {
        int Insert(MemberProfileAddRequest model);
    }
}
