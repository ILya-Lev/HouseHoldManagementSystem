namespace ConsumptionSite.DataContexts.Migrations.Entities
{
	using System.Data.Entity.Migrations;

	public partial class InitialCreation : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"tariff.Tariffs",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Since = c.DateTime(nullable: true),
					Until = c.DateTime(nullable: true),
					Kind = c.Byte(nullable: false),
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"tariff.ConsumptionRanges",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					From = c.Int(),
					To = c.Int(),
					PricePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
					Tariff_Id = c.Int(),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("tariff.Tariffs", t => t.Tariff_Id)
				.Index(t => t.Tariff_Id);

		}

		public override void Down()
		{
			DropForeignKey("tariff.ConsumptionRanges", "Tariff_Id", "tariff.Tariffs");
			DropIndex("tariff.ConsumptionRanges", new[] { "Tariff_Id" });
			DropTable("tariff.ConsumptionRanges");
			DropTable("tariff.Tariffs");
		}
	}
}
