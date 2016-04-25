namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsAuthor5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Author", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Author");
        }
    }
}
