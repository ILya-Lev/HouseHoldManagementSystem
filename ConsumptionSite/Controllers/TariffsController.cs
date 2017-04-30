using ConsumptionSite.DataContexts;
using ConsumptionSite.Models;
using Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ConsumptionSite.Controllers
{
	public class TariffsController : Controller
	{
		private EntityDb _db = new EntityDb();

		public ActionResult Index()
		{
			var allTariffs = _db.Tariffs
				.OrderBy(t => t.Since ?? DateTime.MinValue)
				.ThenBy(t => t.Until ?? DateTime.MaxValue)
				.ToList();
			return View(allTariffs);
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tariff tariff = _db.Tariffs.Find(id);
			if (tariff == null)
			{
				return HttpNotFound();
			}
			return View(tariff);
		}
		//todo: investigate why ConsumptionRangeViewModel ctor conversion instead of ConsumptionRangeViewModel.From leads to an error "Only parameterless constructors and initializers are supported in LINQ to Entities"
		public ActionResult Create()
		{
			if (!_db.ConsumptionRanges.Any())
				return RedirectToAction("Create", "ConsumptionRange");

			var tarifCreateData = new TariffViewModel
			{
				ConsumptionRanges = _db.ConsumptionRanges
					.Select(TariffViewModel.From)
					.ToList()
			};

			return View(tarifCreateData);
		}

		// POST: Tariffs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Since,Until,Kind,ConsumptionRanges")] TariffViewModel tariffViewModel)
		{
			if (ModelState.IsValid)
			{
				var tariff = tariffViewModel.ToTariff(_db);
				_db.Tariffs.Add(tariff);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(tariffViewModel);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tariff tariff = _db.Tariffs.Find(id);
			if (tariff == null)
			{
				return HttpNotFound();
			}

			var tariffViewModel = TariffViewModel.FromTariff(tariff, _db);

			return View(tariffViewModel);
		}

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Since,Until,Kind,ConsumptionRanges")] TariffViewModel tariffViewModel)
		{
			if (ModelState.IsValid)
			{
				var tariff = tariffViewModel.ToTariff(_db);

				foreach (var range in tariff.Ranges)
				{
					range.Tariff = tariff;
					_db.Entry(range).State = EntityState.Modified;
				}
				_db.SaveChanges();

				_db.Entry(tariff).State = EntityState.Modified;
				_db.SaveChanges();

				return RedirectToAction("Index");
			}
			return View(tariffViewModel);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tariff tariff = _db.Tariffs.Find(id);
			if (tariff == null)
			{
				return HttpNotFound();
			}
			return View(tariff);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Tariff tariff = _db.Tariffs.Find(id);
			_db.Tariffs.Remove(tariff);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
