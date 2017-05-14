using AppQuanLyThuHocPhi.Data;
using AppQuanLyThuHocPhi.Data.Repositories;
using AppQuanLyThuHocPhi.Service;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;
using System.Web.Mvc;

namespace AppQuanLyThuHocPhi.Web.App_Start
{
    public class IoCContainer
    {
       

        public static void InitContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(AppQuanLyThuHocPhi.Web.MvcApplication).Assembly);
            builder.RegisterGeneric(typeof(Repo<,>)).As(typeof(IRepo<,>)).WithParameter("db", new QLThuHocPhiDbContext());
            builder.RegisterType<LopRepository>().As<ILopRepository>();
            builder.Register(t => new UnitOfWork()).As<IUnitOfWork>();
            builder.RegisterType<LopService>().As<ILopService>();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}