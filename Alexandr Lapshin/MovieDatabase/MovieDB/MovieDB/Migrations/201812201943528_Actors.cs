namespace MovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BrithdayDate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ActorsMovies",
                c => new
                    {
                        Actors_ID = c.Int(nullable: false),
                        Movies_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actors_ID, t.Movies_ID })
                .ForeignKey("dbo.Actors", t => t.Actors_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .Index(t => t.Actors_ID)
                .Index(t => t.Movies_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorsMovies", "Movies_ID", "dbo.Movies");
            DropForeignKey("dbo.ActorsMovies", "Actors_ID", "dbo.Actors");
            DropIndex("dbo.ActorsMovies", new[] { "Movies_ID" });
            DropIndex("dbo.ActorsMovies", new[] { "Actors_ID" });
            DropTable("dbo.ActorsMovies");
            DropTable("dbo.Actors");
        }
    }
}
