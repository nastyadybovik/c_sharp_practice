namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageChanges3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothes", "FileName", c => c.String());
            DropColumn("dbo.Clothes", "ImageData");
            DropColumn("dbo.Clothes", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clothes", "ImageMimeType", c => c.String());
            AddColumn("dbo.Clothes", "ImageData", c => c.Binary());
            DropColumn("dbo.Clothes", "FileName");
        }
    }
}
