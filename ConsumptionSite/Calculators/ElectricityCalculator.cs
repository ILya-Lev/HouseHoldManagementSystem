using ConsumptionSite.DataContexts;
using ConsumptionSite.Models;
using Entities;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumptionSite.Calculators
{
	public class ElectricityCalculator
	{
		private readonly EntityDb _db;

		public ElectricityCalculator(EntityDb db)
		{
			_db = db;
		}

		public TimePeriodViewModel Evaluate(DateTime? startingDate, DateTime? endingDate)
		{
			var detailedData = new TimePeriodViewModel
			{
				StartingDate = startingDate,
				EndingDate = endingDate,
				Consumptions = GetConsumptions(startingDate, endingDate),
				Tariffs = GetTariffs(startingDate, endingDate),
			};

			detailedData.ConsumptionDetailses = EvaluatePrices(detailedData.Consumptions, detailedData.Tariffs).ToList();

			return detailedData;
		}

		private IEnumerable<ConsumptionDetails> EvaluatePrices(List<Consumption> consumptions, List<Tariff> tariffs)
		{
			foreach (var tariff in tariffs)
			{
				var recordsInTimeRange = consumptions
					.Where(c => c.MeasuredAt >= (tariff.Since ?? DateTime.MinValue) && c.MeasuredAt <= (tariff.Until ?? DateTime.MaxValue))
					.ToList();

				var minRecord = recordsInTimeRange.MinBy(c => c.MeterReadings);
				var maxRecord = recordsInTimeRange.MaxBy(c => c.MeterReadings);

				double consumed = maxRecord.MeterReadings - minRecord.MeterReadings;
				if (tariff.Since != null && tariff.Until != null && maxRecord.MeasuredAt != minRecord.MeasuredAt)
				{
					consumed *= (tariff.Until.Value - tariff.Since.Value).TotalDays
								/ (maxRecord.MeasuredAt - minRecord.MeasuredAt).TotalDays;
				}
				var price = PricePerTariff(consumed, tariff.Ranges);

				var daysElapsed = (int) (tariff.Until.GetValueOrDefault(DateTime.Today)
										 - tariff.Since.GetValueOrDefault(DateTime.Today))
					.TotalDays;
				yield return new ConsumptionDetails
				{
					Consumed = consumed,
					Price = price,
					From = tariff.Since,
					To = tariff.Until,
					DaysElapsed = daysElapsed
				};
			}
		}

		private decimal PricePerTariff(double consumed, List<ConsumptionRange> tariffRanges)
		{
			var total = 0.0m;
			foreach (var range in tariffRanges)
			{
				if (consumed < range.From.GetValueOrDefault(0)) continue;

				if (range.To == null || consumed < range.To)
				{
					total += (decimal) (consumed - range.From.GetValueOrDefault(0)) * range.PricePerUnit;
				}
				else
				{
					total += (decimal) (range.To - range.From.GetValueOrDefault(0)) * range.PricePerUnit;
				}
			}
			return total;
		}

		private List<Tariff> GetTariffs(DateTime? startingDate, DateTime? endingDate)
		{
			return _db.Tariffs
				.Where(t => (t.Since ?? DateTime.MinValue) >= (startingDate ?? DateTime.MinValue)
						 && (t.Until ?? DateTime.MaxValue) <= (endingDate ?? DateTime.MaxValue))
				.OrderBy(t => t.Since)
				.ThenBy(t => t.Until)
				.ToList();
		}

		private List<Consumption> GetConsumptions(DateTime? startingDate, DateTime? endingDate)
		{
			return _db.Consumptions
				.Where(c => c.MeasuredAt >= (startingDate ?? DateTime.MinValue)
						 && c.MeasuredAt <= (endingDate ?? DateTime.MaxValue))
				.OrderBy(c => c.MeasuredAt)
				.ToList();
		}
	}
}