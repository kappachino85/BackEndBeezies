using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Web.Http;
using BackEndBeezies.Web.Services.Interfaces;
using BackEndBeezies.Web.Services;
using BackEndBeezies.Services.Member;
using BackEndBeezies.Services.Interfaces;
using BackEndBeezies.Services;
using BackEndBeezies.Services.Tools;

namespace BackEndBeezies.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			UnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IBaseService, BaseService>(); 
            container.RegisterType<IErrorLogService, ErrorLogService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMemberProfileService, MemberProfileService>();
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            //config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            config.DependencyResolver = new BackEndBeezies.Web.Core.Injection.UnityResolver(container);

        }
    }
}