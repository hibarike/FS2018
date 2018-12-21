using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.DataModel;

namespace MovieDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MovieContext context = new MovieContext())
            {
                Movies movie = new Movies();
                movie.Title = "Logan";
                movie.ReleaseDate = "17 February, 2017";
                movie.Rating = 8.1;
                movie.Duration = 141;
                movie.Language = "English";

                context.Movies.Add(movie);
                context.SaveChanges();

                Genres genre = new Genres();
                genre.GenreName = "Action";

                context.Genres.Add(genre);
                context.SaveChanges();

                Actors actor = new Actors();
                actor.FirstName = "Hugh";
                actor.LastName = "Jackman";
                actor.BrithdayDate = "12 October, 1968";

                context.Actors.Add(actor);
                context.SaveChanges();

                Producers producer = new Producers();
                producer.FirstName = "James";
                producer.LastName = "Mangold";
                producer.BrithdayDate = "16 December, 1963";

                context.Producers.Add(producer);
                context.SaveChanges();

                Countries country = new Countries();
                country.CountryName = "USA";

                context.Countries.Add(country);
                context.SaveChanges();

                Tags tag = new Tags();
                tag.TagName = "X-MAN";

                context.Tags.Add(tag);
                context.SaveChanges();

                Subtitles subtitle = new Subtitles();
                subtitle.Language = "English US";
                subtitle.Studio = "Netflix Originals";

                context.Subtitles.Add(subtitle);
                context.SaveChanges();

                Localization locale = new Localization();
                locale.Language = "Russian";
                locale.Studio = "Fond Kino";

                context.Localizations.Add(locale);
                context.SaveChanges();
            }
        }
    }
}
