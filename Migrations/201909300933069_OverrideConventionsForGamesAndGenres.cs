namespace BoardSeek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForGamesAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Games", "Host_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            DropIndex("dbo.Games", new[] { "Host_Id" });
            AlterColumn("dbo.Games", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Games", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Games", "Host_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Games", "Genre_Id");
            CreateIndex("dbo.Games", "Host_Id");
            AddForeignKey("dbo.Games", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "Host_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Host_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "Host_Id" });
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Games", "Host_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Games", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Games", "Venue", c => c.String());
            CreateIndex("dbo.Games", "Host_Id");
            CreateIndex("dbo.Games", "Genre_Id");
            AddForeignKey("dbo.Games", "Host_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Games", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
