namespace OnlineQuize.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "EncName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "EncName");
        }
    }
}
