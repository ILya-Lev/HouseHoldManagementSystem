using Entities;
using System;
using System.Collections.Generic;

namespace ConsumptionSite.Models
{
	public class TimePeriodViewModel
	{
		public DateTime? StartingDate { get; set; }
		public DateTime? EndingDate { get; set; }
		public List<Consumption> Consumptions { get; set; }
		public List<Tariff> Tariffs { get; set; }
		public List<ConsumptionDetails> ConsumptionDetailses { get; set; }
	}

	public class ConsumptionDetails
	{
		public double Consumed { get; set; }
		public decimal Price { get; set; }
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public int DaysElapsed { get; set; }
	}
}