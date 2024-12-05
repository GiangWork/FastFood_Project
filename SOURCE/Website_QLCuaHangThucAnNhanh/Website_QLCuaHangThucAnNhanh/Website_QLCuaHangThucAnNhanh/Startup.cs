using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_QLCuaHangThucAnNhanh.Startup))]
namespace Website_QLCuaHangThucAnNhanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
