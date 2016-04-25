namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Title", c => c.String(nullable: false));
            AddColumn("dbo.News", "CreationDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "CreationDate");
            DropColumn("dbo.News", "Title");
        }
    }
}
