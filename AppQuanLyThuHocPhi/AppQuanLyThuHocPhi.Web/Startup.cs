using AppQuanLyThuHocPhi.Web.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppQuanLyThuHocPhi.Web.Startup))]
namespace AppQuanLyThuHocPhi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
         
        }
    }
}
