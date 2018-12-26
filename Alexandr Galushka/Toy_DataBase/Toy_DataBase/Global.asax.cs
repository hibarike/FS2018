using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Toy_DataBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
            Genre gn = new Genre();
            gn.Genre_Name = "Rock";
            gn.Id = 1;

            Country cn = new Country();
            cn.Name = "Ukraine";
            cn.Id = 1;
            

            Album alb = new Album();
            alb.Album_Title = "wfhwehfowef";
            alb.Album_Year = "2068";
            alb.Id = 1;
           
            

            Artist art = new Artist();
            art.Id = 1;
            art.Artist_Site_Url = "wfwuhfwhof";
            art.Country = cn;
            art.Genre = gn;
            art.Albums = new List<Album>();
            art.Albums.Add(alb);
            

            Person pr = new Person();
            pr.Id = 1;
            pr.Birthday = "12.43.2333";
            pr.FirstName = "Lukas";
            pr.LastName = "Petrenko";
            pr.Sex = "male";
            pr.Artist = art;
            

            Group gr = new Group();
            gr.Id = 1;
            gr.Name = "qwuefwiue";
            gr.Artists = new List<Artist>();
            gr.Artists.Add(art);
            
            Song song = new Song();
            song.Albums = new List<Album>();
            song.Albums.Add(alb);
            song.Id = 1;
            song.Song_Duration = "wbffbwi";
            song.Song_Title = "jsdjfjdf";

            alb.Artist = art;
            alb.Songs = new List<Song>();
            alb.Songs.Add(song);

            ArtContext db = new ArtContext();
            db.Albums.Add(alb);
            db.Artists.Add(art);
            db.Countrys.Add(cn);
            db.Genres.Add(gn);
            db.Groups.Add(gr);
            db.Persons.Add(pr);
            db.Songs.Add(song);
            db.SaveChanges();
        }
    }
}
