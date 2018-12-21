namespace MovieDB.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MovieContext : DbContext
    {
        // Контекст настроен для использования строки подключения "MovieContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "MovieDB.DataModel.MovieContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MovieContext" 
        // в файле конфигурации приложения.
        public MovieContext()
            : base("name=MovieContext")
        {
        }


        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Subtitles> Subtitles { get; set; }
        public DbSet<Localization> Localizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}