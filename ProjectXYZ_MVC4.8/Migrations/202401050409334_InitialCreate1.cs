namespace ProjectXYZ_MVC4._8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyEmail = c.String(),
                        Phone = c.String(maxLength: 4000),
                        ApprovalStatus = c.String(maxLength: 4000),
                        CompanyPhoto = c.Binary(),
                        CompanyID = c.Int(),
                    })
                .PrimaryKey(t => t.CID)
                .ForeignKey("dbo.Users", t => t.CompanyID)
                .Index(t => t.CID, unique: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        UserType = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        ManagerID = c.Int(nullable: false),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UID)
                .ForeignKey("dbo.Vendors", t => t.UserID)
                .Index(t => t.UID, unique: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        MID = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(maxLength: 4000),
                        ManagerEmail = c.String(maxLength: 4000),
                        ManagerPhone = c.String(maxLength: 4000),
                        ManagerID = c.Int(),
                    })
                .PrimaryKey(t => t.MID)
                .ForeignKey("dbo.Users", t => t.ManagerID)
                .Index(t => t.MID, unique: true)
                .Index(t => t.ManagerID);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorID = c.Int(nullable: false, identity: true),
                        vendorName = c.String(),
                        businessType = c.String(maxLength: 4000),
                        companyType = c.String(maxLength: 4000),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendorID)
                .Index(t => t.VendorID, unique: true);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        VendorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Vendors", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.ProjectID, unique: true)
                .Index(t => t.VendorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserID", "dbo.Vendors");
            DropForeignKey("dbo.Projects", "VendorID", "dbo.Vendors");
            DropForeignKey("dbo.Managers", "ManagerID", "dbo.Users");
            DropForeignKey("dbo.Companies", "CompanyID", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "VendorID" });
            DropIndex("dbo.Projects", new[] { "ProjectID" });
            DropIndex("dbo.Vendors", new[] { "VendorID" });
            DropIndex("dbo.Managers", new[] { "ManagerID" });
            DropIndex("dbo.Managers", new[] { "MID" });
            DropIndex("dbo.Users", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "UID" });
            DropIndex("dbo.Companies", new[] { "CompanyID" });
            DropIndex("dbo.Companies", new[] { "CID" });
            DropTable("dbo.Projects");
            DropTable("dbo.Vendors");
            DropTable("dbo.Managers");
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
        }
    }
}
