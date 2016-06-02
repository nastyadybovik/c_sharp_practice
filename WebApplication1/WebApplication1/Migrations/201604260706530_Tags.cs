namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagNews",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        News_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.News_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.News_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.News_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagNews", "News_Id", "dbo.News");
            DropForeignKey("dbo.TagNews", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagNews", new[] { "News_Id" });
            DropIndex("dbo.TagNews", new[] { "Tag_Id" });
            DropTable("dbo.TagNews");
            DropTable("dbo.Tags");
        }
    }
}
