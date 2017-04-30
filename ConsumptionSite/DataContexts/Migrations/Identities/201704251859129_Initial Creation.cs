namespace ConsumptionSite.DataContexts.Migrations.Identities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ientity.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "ientity.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("ientity.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("ientity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "ientity.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "ientity.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ientity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "ientity.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("ientity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ientity.AspNetUserRoles", "UserId", "ientity.AspNetUsers");
            DropForeignKey("ientity.AspNetUserLogins", "UserId", "ientity.AspNetUsers");
            DropForeignKey("ientity.AspNetUserClaims", "UserId", "ientity.AspNetUsers");
            DropForeignKey("ientity.AspNetUserRoles", "RoleId", "ientity.AspNetRoles");
            DropIndex("ientity.AspNetUserLogins", new[] { "UserId" });
            DropIndex("ientity.AspNetUserClaims", new[] { "UserId" });
            DropIndex("ientity.AspNetUsers", "UserNameIndex");
            DropIndex("ientity.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("ientity.AspNetUserRoles", new[] { "UserId" });
            DropIndex("ientity.AspNetRoles", "RoleNameIndex");
            DropTable("ientity.AspNetUserLogins");
            DropTable("ientity.AspNetUserClaims");
            DropTable("ientity.AspNetUsers");
            DropTable("ientity.AspNetUserRoles");
            DropTable("ientity.AspNetRoles");
        }
    }
}
