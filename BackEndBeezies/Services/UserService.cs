using BackEndBeezies.Services.Interfaces;
using BackEndBeezies.Web.Models;
using BackEndBeezies.Web.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BackEndBeezies.Web.Services
{
    public class UserService : IUserService
    {
        IBaseService _baseService;

        public UserService(IBaseService baseService, IErrorLogService errorLogService)
        {
            _baseService = baseService;
            _baseService.ErrorLog = errorLogService;
        }

        private ApplicationUserManager GetUserManager()
        {
            try
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public IdentityUser CreateUser(string email, string password)
        {
            try
            {
                ApplicationUserManager userManager = GetUserManager();

                ApplicationUser newUser = new ApplicationUser { UserName = email, Email = email, LockoutEnabled = false };
                IdentityResult result = null;

                result = userManager.Create(newUser, password);

                if (result.Succeeded)
                {
                    return newUser;
                }
                else
                {
                    throw new Exception("User Service Error");
                }
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public ServiceResponse Login(string email, string password)
        {
            try
            {
                bool result = false;

                if (!IsUser(email))
                {
                    return new ServiceResponse { IsSuccessful = false, ResponseMessage = "Email was Not Found" };
                }

                ApplicationUserManager userManager = GetUserManager();
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                ApplicationUser user = userManager.Find(email, password);


                if (user != null)
                {
                    ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);
                    return new ServiceResponse { IsSuccessful = true, ResponseMessage = "Success" };
                }
                return new ServiceResponse { IsSuccessful = result, ResponseMessage = "Password was Invalid" };
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public bool IsUser(string email)
        {
            try
            {
                bool result = false;

                ApplicationUserManager userManager = GetUserManager();
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                ApplicationUser user = userManager.FindByEmail(email);

                if (user != null)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public ApplicationUser GetUserById(string userId)
        {
            try
            {
                ApplicationUserManager userManager = GetUserManager();
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                ApplicationUser user = userManager.FindById(userId);

                return user;
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public bool Logout()
        {
            try
            {
                bool result = false;

                IdentityUser user = GetCurrentUser();

                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public IdentityUser GetCurrentUser()
        {
            try
            {
                if (!IsLoggedIn())
                {
                    return null;
                }
                ApplicationUserManager userManager = GetUserManager();

                IdentityUser currentUserId = userManager.FindById(GetCurrentUserId());
                return currentUserId;
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }

        public string GetCurrentUserId()
        {
            try
            {
                return HttpContext.Current.User.Identity.GetUserId();
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }


        public bool IsLoggedIn()
        {
            try
            {
                return !string.IsNullOrEmpty(GetCurrentUserId());
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "UserService");
                throw;
            }
        }
    }
}