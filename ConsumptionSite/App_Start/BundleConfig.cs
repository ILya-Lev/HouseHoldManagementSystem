using System.Web.Optimization;

namespace ConsumptionSite
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/detetime").Include(
						"~/Scripts/moment-*",
						"~/Scripts/bootstrap-datetimepicker-*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			var sortableTableBundle = new ScriptBundle("~/bundles/stupidtable");
			sortableTableBundle.Include("~/Scripts/stupidtable-*");
			bundles.Add(sortableTableBundle);

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/bootstrap-datetimepicker.css",
					  "~/Content/site.css",
					  "~/Content/common-*",
					  "~/Content/kendo/kendo.common.core.min.css",
					  "~/Content/kendo/kendo.default.min.css"));
		}
	}
}
