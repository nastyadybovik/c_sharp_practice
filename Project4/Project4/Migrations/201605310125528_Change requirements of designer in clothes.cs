namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changerequirementsofdesignerinclothes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clothes", "Designer_Id", "dbo.Designers");
            DropIndex("dbo.Clothes", new[] { "Designer_Id" });
            AlterColumn("dbo.Clothes", "Designer_Id", c => c.Int());
            CreateIndex("dbo.Clothes", "Designer_Id");
            AddForeignKey("dbo.Clothes", "Designer_Id", "dbo.Designers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clothes", "Designer_Id", "dbo.Designers");
            DropIndex("dbo.Clothes", new[] { "Designer_Id" });
            AlterColumn("dbo.Clothes", "Designer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Clothes", "Designer_Id");
            AddForeignKey("dbo.Clothes", "Designer_Id", "dbo.Designers", "Id", cascadeDelete: true);
        }
    }
}
