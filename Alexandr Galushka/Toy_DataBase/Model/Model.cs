using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Model
{
    public class ArtContext : DbContext
    {
        public ArtContext() : base("Art") { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
    }





    public class Artist
    {
        public int Id { get; set; }
        public Genre Genre { get; set; }
        public Country Country { get; set; }
        public string Artist_Site_Url { get; set; }
        public ICollection<Album> Albums { get; set; }

    }

    public class Genre
    {
        public int Id { get; set; }
        public string Genre_Name { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public string Name { get; set; }

    }

    public class Person
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }

    }

    public class Album
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public string Album_Title { get; set; }
        public string Album_Year { get; set; }
        public ICollection<Song> Songs { get; set; }
    }

    public class Song
    {
        public int Id { get; set; }
        public string Song_Title { get; set; }
        public string Song_Duration { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
