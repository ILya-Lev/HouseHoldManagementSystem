namespace ConsumptionSite.DataContexts.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsumptionEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tariff.Consumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeterReadings = c.Int(nullable: false),
                        MeasuredAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("tariff.Consumptions");
        }
    }
}
