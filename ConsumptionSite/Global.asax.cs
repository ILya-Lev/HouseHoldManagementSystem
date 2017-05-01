using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConsumptionSite
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Application_MapRequestHandler() => Debug.Print("Map Request Handler");
		protected void Application_PostMapRequestHandler() => Debug.Print("Post Map Request Handler");
		protected void Application_AcquireRequestState() => Debug.Print("Acquire Request State");
		protected void Application_PreRequestHandlerExecute() => Debug.Print("Pre Request Handler Execute");
		protected void Application_PostRequestHandlerExecute() => Debug.Print("Post Request Handler Execute");
	}
}
