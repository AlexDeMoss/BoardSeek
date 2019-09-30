namespace BoardSeek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Tabletop RPG')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Cards')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Board Games')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Classic Board Games')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
