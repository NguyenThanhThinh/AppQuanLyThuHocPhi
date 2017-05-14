using AppQuanLyThuHocPhi.Data;
using AppQuanLyThuHocPhi.Data.Repositories;
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
        public static IContainer Container { get; private set; }

        public static void InitContainer()
        {
            var builder = new ContainerBuilder();

          
            // register generic repository         
            builder.RegisterGeneric(typeof(GenericRepository<,>))
                .As(typeof(IGenericRepository<,>))
                .WithParameter("db", new QLThuHocPhiDbContext());

            // register repositories
            builder.Register(t => new LopRepository(new QLThuHocPhiDbContext())).As<ILopRepository>();
           
            //builder.Register((context, paras) => new PostRepository(paras.Named<Db>("p1"))).As<IPostRepository>();           
            builder.RegisterControllers(typeof(AppQuanLyThuHocPhi.Web.MvcApplication).Assembly);

            // opt: register model binder
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // opt: register web abstractions
            builder.RegisterModule<AutofacWebTypesModule>();

            // opt: enable property injection in view pages
            builder.RegisterSource(new ViewRegistrationSource());

            // opt: enable property injection into action filters
            builder.RegisterFilterProvider();

            // set the dependency resolver to to autofac
            // var container = builder.Build();
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            // using service locator
            #region sl
            var csl = new AutofacServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => csl);
            #endregion
        }
    }
}