using System.Data.Entity;
using ConsumptionSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConsumptionSite.DataContexts
{
	public class IdentityDb : IdentityDbContext<ApplicationUser>
	{
		public IdentityDb()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static IdentityDb Create()
		{
			return new IdentityDb();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("ientity");
			base.OnModelCreating(modelBuilder);
		}
	}
}