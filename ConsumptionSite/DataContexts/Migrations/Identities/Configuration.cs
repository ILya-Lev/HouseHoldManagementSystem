using System.Data.Entity.Migrations;

namespace ConsumptionSite.DataContexts.Migrations.Identities
{
	internal sealed class Configuration : DbMigrationsConfiguration<IdentityDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			MigrationsDirectory = @"DataContexts\Migrations\Identities";
		}

		protected override void Seed(IdentityDb context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}
