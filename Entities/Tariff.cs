using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Entities
{
	[DebuggerDisplay("from {Since} to {Until} has {Ranges.Count}")]
	[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
	public class Tariff
	{
		public int Id { get; set; }

		/// <summary> the tariff is applicable since the date </summary>
		public DateTime? Since { get; set; }

		/// <summary> the tariff is applicable until the date </summary>
		public DateTime? Until { get; set; }

		/// <summary> a type of service the tariff is for (e.g. electricity) </summary>
		public ServiceKind Kind { get; set; }

		public virtual List<ConsumptionRange> Ranges { get; set; }
	}
}