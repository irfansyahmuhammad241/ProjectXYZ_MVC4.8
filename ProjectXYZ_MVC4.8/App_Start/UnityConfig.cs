using ProjectXYZ_MVC4._8.Contracts;
using ProjectXYZ_MVC4._8.Repositories;
using ProjectXYZ_MVC4._8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ProjectXYZ_MVC4._8.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer Container { get; internal set; }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Registrasi layanan di sini
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<CompanyServices>();

            container.RegisterType<IManagerRepository, ManagerRepository>();
            container.RegisterType<ManagerServices>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}