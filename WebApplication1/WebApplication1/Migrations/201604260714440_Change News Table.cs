namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNewsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Author", c => c.Int(nullable: false));
        }
    }
}
