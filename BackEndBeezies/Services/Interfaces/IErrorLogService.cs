using BackEndBeezies.Models.Requests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBeezies.Services.Interfaces
{
    public interface IErrorLogService
    {
        int Insert(ErrorLogAddRequest model);
    }
}
