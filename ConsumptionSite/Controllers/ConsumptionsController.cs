using ConsumptionSite.DataContexts;
using Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ConsumptionSite.Controllers
{
	public class ConsumptionsController : Controller
	{
		private EntityDb _db = new EntityDb();

		// GET: Consumptions
		public ActionResult Index()
		{
			return View(_db.Consumptions.ToList());
		}

		// GET: Consumptions/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Consumption consumption = _db.Consumptions.Find(id);
			if (consumption == null)
			{
				return HttpNotFound();
			}
			return View(consumption);
		}

		// GET: Consumptions/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Consumptions/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,MeterReadings,MeasuredAt")] Consumption consumption)
		{
			if (ModelState.IsValid)
			{
				_db.Consumptions.Add(consumption);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(consumption);
		}

		// GET: Consumptions/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Consumption consumption = _db.Consumptions.Find(id);
			if (consumption == null)
			{
				return HttpNotFound();
			}
			return View(consumption);
		}

		// POST: Consumptions/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,MeterReadings,MeasuredAt")] Consumption consumption)
		{
			if (ModelState.IsValid)
			{
				_db.Entry(consumption).State = EntityState.Modified;
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(consumption);
		}

		// GET: Consumptions/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Consumption consumption = _db.Consumptions.Find(id);
			if (consumption == null)
			{
				return HttpNotFound();
			}
			return View(consumption);
		}

		// POST: Consumptions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Consumption consumption = _db.Consumptions.Find(id);
			_db.Consumptions.Remove(consumption);
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
