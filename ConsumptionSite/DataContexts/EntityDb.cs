using Entities;
using System.Data.Entity;
using System.Diagnostics;

namespace ConsumptionSite.DataContexts
{
	public class EntityDb : DbContext
	{
		public EntityDb()
			: base("DefaultConnection")
		{
			Database.Log = sql => Debug.Print(sql);
		}

		public DbSet<Tariff> Tariffs { get; set; }
		public DbSet<ConsumptionRange> ConsumptionRanges { get; set; }
		public DbSet<Consumption> Consumptions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("tariff");
			base.OnModelCreating(modelBuilder);
		}
	}
}