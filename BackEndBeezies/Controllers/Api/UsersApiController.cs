using BackEndBeezies.Models.Requests.Member;
using BackEndBeezies.Models.Responses;
using BackEndBeezies.Models.Responses.Member;
using BackEndBeezies.Web.Models;
using BackEndBeezies.Web.Services.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEndBeezies.Web.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {
        IUserService _userService;
        IMemberProfileService _memberProfileService;

        public UsersApiController(IUserService userService, IMemberProfileService memberProfileService)
        {
            _userService = userService;
            _memberProfileService = memberProfileService;
        }

        [AllowAnonymous]
        [Route("register"), HttpPost]
        public HttpResponseMessage Register(RegistrationAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }
            try
            {
                IdentityUser user = _userService.CreateUser(model.Email, model.Password);

                if(user != null)
                {
                    RegistrationResponse response = new RegistrationResponse();
                    response.AspNetUserID = user.Id;
                    response.Email = model.Email;
                    response.MemberProfileId = _memberProfileService.Insert(new MemberProfileAddRequest
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Gender = model.Gender,
                        AspNetUserId = user.Id
                       
                    });

                    if (response.MemberProfileId > 0)
                    {
                        try
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, response);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Registration Success");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("login"), HttpPost]
        public HttpResponseMessage Login(LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }
            SuccessResponse response = new SuccessResponse();
            try
            {
                ServiceResponse status = _userService.Login(model.Email, model.Password);
                if (status.IsSuccessful)
                {
                    ItemResponse<bool> response2 = new ItemResponse<bool> { Item = status.IsSuccessful };
                    return Request.CreateResponse(HttpStatusCode.OK, response2);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, status.ResponseMessage);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("logout"), HttpGet]
        public HttpResponseMessage UserLogout()
        {
            SuccessResponse response = new SuccessResponse();
            try
            {
                _userService.Logout();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
