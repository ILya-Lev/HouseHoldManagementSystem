using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConsumptionSite.Startup))]
namespace ConsumptionSite
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
