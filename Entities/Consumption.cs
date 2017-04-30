using System;
using System.Diagnostics;

namespace Entities
{
	[DebuggerDisplay("{MeterReadings} at {MeasuredAt}")]
	public class Consumption
	{
		public int Id { get; set; }
		public int MeterReadings { get; set; }
		public DateTime MeasuredAt { get; set; }
	}
}
