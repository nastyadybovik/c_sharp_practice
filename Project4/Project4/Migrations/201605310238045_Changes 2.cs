namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothes", "ImageData", c => c.Binary());
            AddColumn("dbo.Clothes", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clothes", "ImageMimeType");
            DropColumn("dbo.Clothes", "ImageData");
        }
    }
}
