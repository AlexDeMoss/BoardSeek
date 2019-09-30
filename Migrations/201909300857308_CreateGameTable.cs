namespace BoardSeek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGameTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Genre_Id = c.Byte(),
                        Host_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Host_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Host_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Host_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "Host_Id" });
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
        }
    }
}
