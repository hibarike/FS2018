namespace MovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ReleaseDate = c.String(),
                        Rating = c.Double(nullable: false),
                        Duration = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MoviesGenres",
                c => new
                    {
                        Movies_ID = c.Int(nullable: false),
                        Genres_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movies_ID, t.Genres_ID })
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genres_ID, cascadeDelete: true)
                .Index(t => t.Movies_ID)
                .Index(t => t.Genres_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoviesGenres", "Genres_ID", "dbo.Genres");
            DropForeignKey("dbo.MoviesGenres", "Movies_ID", "dbo.Movies");
            DropIndex("dbo.MoviesGenres", new[] { "Genres_ID" });
            DropIndex("dbo.MoviesGenres", new[] { "Movies_ID" });
            DropTable("dbo.MoviesGenres");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
