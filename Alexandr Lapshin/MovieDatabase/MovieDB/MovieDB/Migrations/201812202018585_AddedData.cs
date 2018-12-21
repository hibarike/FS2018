namespace MovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedData : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MoviesGenres", newName: "GenresMovies");
            RenameTable(name: "dbo.ActorsMovies", newName: "MoviesActors");
            DropPrimaryKey("dbo.GenresMovies");
            DropPrimaryKey("dbo.MoviesActors");
            AddPrimaryKey("dbo.GenresMovies", new[] { "Genres_ID", "Movies_ID" });
            AddPrimaryKey("dbo.MoviesActors", new[] { "Movies_ID", "Actors_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MoviesActors");
            DropPrimaryKey("dbo.GenresMovies");
            AddPrimaryKey("dbo.MoviesActors", new[] { "Actors_ID", "Movies_ID" });
            AddPrimaryKey("dbo.GenresMovies", new[] { "Movies_ID", "Genres_ID" });
            RenameTable(name: "dbo.MoviesActors", newName: "ActorsMovies");
            RenameTable(name: "dbo.GenresMovies", newName: "MoviesGenres");
        }
    }
}
