using System.Diagnostics;

namespace Entities
{
	[DebuggerDisplay("{PricePerUnit} [{From};{To}] for {Tariff?.Id}")]
	public class ConsumptionRange
	{
		public int Id { get; set; }

		/// <summary> amount of consumed Units the price is applicable *from* </summary>
		public int? From { get; set; }

		/// <summary> amount of consumed Units the price is applicable *to* </summary>
		public int? To { get; set; }

		public decimal PricePerUnit { get; set; }

		public Tariff Tariff { get; set; }
	}
}
