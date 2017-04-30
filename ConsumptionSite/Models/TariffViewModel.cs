using ConsumptionSite.DataContexts;
using Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumptionSite.Models
{
	public class TariffViewModel
	{
		public int? Id { get; set; }
		public DateTime? Since { get; set; }
		public DateTime? Until { get; set; }
		public ServiceKind Kind { get; set; }
		public List<string> ConsumptionRanges { get; set; }

		public Tariff ToTariff(EntityDb db)
		{
			var allRanges = db.ConsumptionRanges.ToList();
			var targetRanges = allRanges
				.Select(r => new { Range = r, Description = From(r) })
				.Where(item => ConsumptionRanges.Contains(item.Description))
				.DistinctBy(item => item.Range.Id)
				.Select(item => item.Range)
				.ToList();

			var tariff = db.Tariffs.FirstOrDefault(t => t.Id == Id) ?? new Tariff { Id = Id ?? 0 };

			tariff.Since = Since;
			tariff.Until = Until;
			tariff.Kind = Kind;
			tariff.Ranges = targetRanges;

			return tariff;
		}

		public static TariffViewModel FromTariff(Tariff tariff, EntityDb db)
		{
			return new TariffViewModel
			{
				Id = tariff.Id,
				Since = tariff.Since,
				Until = tariff.Until,
				Kind = tariff.Kind,
				ConsumptionRanges = db.ConsumptionRanges.Select(From).ToList(),
			};
		}

		public static string From(ConsumptionRange range)
		{
			return $"[{range.From};{range.To}] {range.PricePerUnit} UAH";
		}
	}
}