using System.Data.Entity.Migrations;

namespace ConsumptionSite.DataContexts.Migrations.Entities
{
	internal sealed class Configuration : DbMigrationsConfiguration<EntityDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			MigrationsDirectory = @"DataContexts\Migrations\Entities";
		}

		protected override void Seed(EntityDb context)
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
