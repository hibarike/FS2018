using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieDB.DataModel
{
    public class Movies
    {
        public Movies()
        {
            this.Genres = new HashSet<Genres>();
            this.Actors = new HashSet<Actors>();
        }

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public double Rating { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }

        public virtual ICollection<Genres> Genres { get; set; }
        public virtual ICollection<Actors> Actors { get; set; }
        public virtual ICollection<Producers> Producers { get; set; }
        public virtual ICollection<Countries> Countries { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
        public virtual ICollection<Subtitles> Subtitles { get; set; }
        public virtual ICollection<Localization> Localization { get; set; }
    }

    public class Genres
    {
        public Genres()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }

    public class Actors
    {
        public Actors()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrithdayDate { get; set; }


        public virtual ICollection<Movies> Movies { get; set; }
    }

    public class Producers
    {
        public Producers()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrithdayDate { get; set; }


        public virtual ICollection<Movies> Movies { get; set; }
    }

    public class Countries
    {
        public Countries()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }

    public class Tags
    {
        public Tags()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }

    public class Subtitles
    {
        public Subtitles()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string Language { get; set; }
        public string Studio { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }

    public class Localization
    {
        public Localization()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int ID { get; set; }
        public string Language { get; set; }
        public string Studio { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
