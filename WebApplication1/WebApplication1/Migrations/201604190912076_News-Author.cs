namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsAuthor : DbMigration
    {
        //Update-Database  -  выолняет этот метод upgrade
        public override void Up()
        {
            AddColumn("dbo.News", "Author_Id", c => c.Int());
            CreateIndex("dbo.News", "Author_Id");
            AddForeignKey("dbo.News", "Author_Id", "dbo.Authors", "Id");
            DropColumn("dbo.News", "Author");
        }
        
        //Откат - downgrade
        public override void Down()
        {
            AddColumn("dbo.News", "Author", c => c.String());
            DropForeignKey("dbo.News", "Author_Id", "dbo.Authors");
            DropIndex("dbo.News", new[] { "Author_Id" });
            DropColumn("dbo.News", "Author_Id");
        }
    }
}
