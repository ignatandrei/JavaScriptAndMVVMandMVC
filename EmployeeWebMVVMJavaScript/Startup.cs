using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeWebMVVMJavaScript.Startup))]
namespace EmployeeWebMVVMJavaScript
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
