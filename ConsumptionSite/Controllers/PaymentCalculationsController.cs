using ConsumptionSite.Calculators;
using ConsumptionSite.DataContexts;
using ConsumptionSite.Models;
using System.Web.Mvc;

namespace ConsumptionSite.Controllers
{
	public class PaymentCalculationsController : Controller
	{
		private readonly ElectricityCalculator _calculator;

		public PaymentCalculationsController()
		{
			_calculator = new ElectricityCalculator(new EntityDb());
		}

		[Route("/PaymentCalculations/DateRange")]
		public ActionResult DateRange()
		{
			ViewBag.HasDetails = false;
			return View("Preconditions");
		}

		[Route("/PaymentCalculations/DateRange")]
		[HttpPost]
		public ActionResult DateRange([Bind(Include = "StartingDate,EndingDate")] TimePeriodViewModel data)
		{
			ViewBag.HasDetails = false;
			if (!ModelState.IsValid)
				return View("Preconditions");

			var detailedData = _calculator.Evaluate(data.StartingDate, data.EndingDate);
			ViewBag.HasDetails = true;
			return View("Preconditions", detailedData);
		}
	}
}