namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsAuthor4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "Author_Id", "dbo.Authors");
            DropIndex("dbo.News", new[] { "Author_Id" });
            RenameColumn(table: "dbo.News", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.News", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "AuthorId");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropIndex("dbo.News", new[] { "AuthorId" });
            AlterColumn("dbo.News", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.News", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.News", "Author_Id");
            AddForeignKey("dbo.News", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
