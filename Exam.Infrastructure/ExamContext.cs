using ApplicationCore.Domain;
using Exam.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure
{
    public class ExamContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;

             Initial Catalog=HarounjlassiArtist;Integrated Security=true;
                  MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       

            modelBuilder.Entity<Concert>().HasOne(artistc => artistc.Artiste)
               .WithMany(concerets => concerets.concerts)
               .HasForeignKey(c => c.ArtisteFk);

            modelBuilder.Entity<Concert>().HasOne(fs => fs.Festival)
                      .WithMany(concerets => concerets.concerts)
                      .HasForeignKey(c => c.FestivalFk);

            modelBuilder.Entity<Concert>().HasKey(c => new { c.DateConcert, c.FestivalFk, c.ArtisteFk });
            //modelBuilder.ApplyConfiguration(new ConcertsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //"For every string property in all your entities, apply a maximum length constraint of 150 characters."

            //    // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);
            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);
         
            configurationBuilder.Properties<string>().HaveMaxLength(50);
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
