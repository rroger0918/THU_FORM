using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(THU_FORM.App_Start.StartUp))]
namespace THU_FORM.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}