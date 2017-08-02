using BackEndBeezies.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBeezies.Web.Services.Interfaces
{
    public interface IUserService
    {
        IdentityUser CreateUser(string email, string password);

        ServiceResponse Login(string email, string password);

        bool IsUser(string email);

        ApplicationUser GetUserById(string userId);

        bool Logout();

        IdentityUser GetCurrentUser();

        string GetCurrentUserId();

        bool IsLoggedIn();
    }
}
