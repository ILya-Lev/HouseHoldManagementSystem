using ConsumptionSite.DataContexts;
using Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ConsumptionSite.Controllers
{
	public class ConsumptionRangeController : Controller
	{
		private EntityDb _db = new EntityDb();

		public ActionResult Index()
		{
			return View(_db.ConsumptionRanges.ToList());
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,From,To,PricePerUnit")] ConsumptionRange range)
		{
			if (ModelState.IsValid)
			{
				_db.ConsumptionRanges.Add(range);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return Create(range);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var range = _db.ConsumptionRanges.Find(id);
			if (range == null)
			{
				return HttpNotFound();
			}
			return View(range);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,From,To,PricePerUnit")] ConsumptionRange range)
		{
			if (ModelState.IsValid)
			{
				_db.Entry(range).State = EntityState.Modified;
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(range);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var range = _db.ConsumptionRanges.Find(id);
			if (range == null)
			{
				return HttpNotFound();
			}
			return View(range);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var range = _db.ConsumptionRanges.Find(id);
			_db.ConsumptionRanges.Remove(range);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}