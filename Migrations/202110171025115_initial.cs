namespace OnlineQuize.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        CName = c.String(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CId)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QId = c.Int(nullable: false, identity: true),
                        QName = c.String(nullable: false),
                        OpA = c.String(nullable: false),
                        OpB = c.String(nullable: false),
                        OpC = c.String(nullable: false),
                        OpD = c.String(nullable: false),
                        CuurectAns = c.String(nullable: false),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QId)
                .ForeignKey("dbo.Categories", t => t.CatId, cascadeDelete: true)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.Scholars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CPassword = c.String(),
                        Profile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Set_Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Exam_Name = c.String(nullable: false),
                        Exam_Date = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        Scholar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scholars", t => t.Scholar_Id, cascadeDelete: true)
                .Index(t => t.Scholar_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Set_Exam", "Scholar_Id", "dbo.Scholars");
            DropForeignKey("dbo.Questions", "CatId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "AdminId", "dbo.Admins");
            DropIndex("dbo.Set_Exam", new[] { "Scholar_Id" });
            DropIndex("dbo.Questions", new[] { "CatId" });
            DropIndex("dbo.Categories", new[] { "AdminId" });
            DropTable("dbo.Set_Exam");
            DropTable("dbo.Scholars");
            DropTable("dbo.Questions");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
