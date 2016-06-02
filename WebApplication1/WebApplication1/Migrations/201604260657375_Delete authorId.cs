namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteauthorId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropIndex("dbo.News", new[] { "AuthorId" });
            RenameColumn(table: "dbo.News", name: "AuthorId", newName: "Author_Id");
            AlterColumn("dbo.News", "Author_Id", c => c.Int());
            CreateIndex("dbo.News", "Author_Id");
            AddForeignKey("dbo.News", "Author_Id", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "Author_Id", "dbo.Authors");
            DropIndex("dbo.News", new[] { "Author_Id" });
            AlterColumn("dbo.News", "Author_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.News", name: "Author_Id", newName: "AuthorId");
            CreateIndex("dbo.News", "AuthorId");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
