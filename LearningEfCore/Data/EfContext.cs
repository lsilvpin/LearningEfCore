using LearningEfCore.Entities;
using LearningEfCore.Models;
using LearningEfCore.Tools;
using Microsoft.EntityFrameworkCore;
using System;

namespace LearningEfCore.Data
{
    class EfContext : DbContext
    {
        private readonly string connectionString;

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        public EfContext(PathHandler pathHandler,
            JsonHandler<AppConfig> jsonHandler) : base()
        {
            string configPath = pathHandler.MapPath(@"LearningEfCore\appsettings.json");
            AppConfig config = jsonHandler.Deserialize(configPath);
            connectionString = config.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
                throw new ArgumentNullException(nameof(optionsBuilder));

            optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("LearningEfCore"));

            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
