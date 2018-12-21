namespace MovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Localizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                        Studio = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BrithdayDate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subtitles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                        Studio = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CountriesMovies",
                c => new
                    {
                        Countries_ID = c.Int(nullable: false),
                        Movies_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Countries_ID, t.Movies_ID })
                .ForeignKey("dbo.Countries", t => t.Countries_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .Index(t => t.Countries_ID)
                .Index(t => t.Movies_ID);
            
            CreateTable(
                "dbo.LocalizationMovies",
                c => new
                    {
                        Localization_ID = c.Int(nullable: false),
                        Movies_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Localization_ID, t.Movies_ID })
                .ForeignKey("dbo.Localizations", t => t.Localization_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .Index(t => t.Localization_ID)
                .Index(t => t.Movies_ID);
            
            CreateTable(
                "dbo.ProducersMovies",
                c => new
                    {
                        Producers_ID = c.Int(nullable: false),
                        Movies_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Producers_ID, t.Movies_ID })
                .ForeignKey("dbo.Producers", t => t.Producers_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .Index(t => t.Producers_ID)
                .Index(t => t.Movies_ID);
            
            CreateTable(
                "dbo.SubtitlesMovies",
                c => new
                    {
                        Subtitles_ID = c.Int(nullable: false),
                        Movies_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subtitles_ID, t.Movies_ID })
                .ForeignKey("dbo.Subtitles", t => t.Subtitles_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .Index(t => t.Subtitles_ID)
                .Index(t => t.Movies_ID);
            
            CreateTable(
                "dbo.TagsMovies",
                c => new
                    {
                        Tags_ID = c.Int(nullable: false),
                        Movies_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tags_ID, t.Movies_ID })
                .ForeignKey("dbo.Tags", t => t.Tags_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_ID, cascadeDelete: true)
                .Index(t => t.Tags_ID)
                .Index(t => t.Movies_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsMovies", "Movies_ID", "dbo.Movies");
            DropForeignKey("dbo.TagsMovies", "Tags_ID", "dbo.Tags");
            DropForeignKey("dbo.SubtitlesMovies", "Movies_ID", "dbo.Movies");
            DropForeignKey("dbo.SubtitlesMovies", "Subtitles_ID", "dbo.Subtitles");
            DropForeignKey("dbo.ProducersMovies", "Movies_ID", "dbo.Movies");
            DropForeignKey("dbo.ProducersMovies", "Producers_ID", "dbo.Producers");
            DropForeignKey("dbo.LocalizationMovies", "Movies_ID", "dbo.Movies");
            DropForeignKey("dbo.LocalizationMovies", "Localization_ID", "dbo.Localizations");
            DropForeignKey("dbo.CountriesMovies", "Movies_ID", "dbo.Movies");
            DropForeignKey("dbo.CountriesMovies", "Countries_ID", "dbo.Countries");
            DropIndex("dbo.TagsMovies", new[] { "Movies_ID" });
            DropIndex("dbo.TagsMovies", new[] { "Tags_ID" });
            DropIndex("dbo.SubtitlesMovies", new[] { "Movies_ID" });
            DropIndex("dbo.SubtitlesMovies", new[] { "Subtitles_ID" });
            DropIndex("dbo.ProducersMovies", new[] { "Movies_ID" });
            DropIndex("dbo.ProducersMovies", new[] { "Producers_ID" });
            DropIndex("dbo.LocalizationMovies", new[] { "Movies_ID" });
            DropIndex("dbo.LocalizationMovies", new[] { "Localization_ID" });
            DropIndex("dbo.CountriesMovies", new[] { "Movies_ID" });
            DropIndex("dbo.CountriesMovies", new[] { "Countries_ID" });
            DropTable("dbo.TagsMovies");
            DropTable("dbo.SubtitlesMovies");
            DropTable("dbo.ProducersMovies");
            DropTable("dbo.LocalizationMovies");
            DropTable("dbo.CountriesMovies");
            DropTable("dbo.Tags");
            DropTable("dbo.Subtitles");
            DropTable("dbo.Producers");
            DropTable("dbo.Localizations");
            DropTable("dbo.Countries");
        }
    }
}
