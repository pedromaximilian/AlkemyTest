using AlkemyTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public  DbSet<Character> Characters { get; set; }
        public  DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public  DbSet<Character_Movie> Character_Movies { get; set; }
        public DbSet<Movie_Genre> GetMovie_Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Names must be unique
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasIndex(t => t.Name)
                .IsUnique();
            });

            //Titles must be unique
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasIndex(t => t.Title)
                .IsUnique();
            });

            //Names must be unique
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(t => t.Name)
                .IsUnique();
            });



            //compound key and many-yo many
            modelBuilder.Entity<Movie_Genre>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId });
                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movie_Genres)
                    .HasForeignKey(d => d.GenreId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Movie_Genres)
                    .HasForeignKey(d => d.MovieId);

            });


            //compound key and many-yo many
            modelBuilder.Entity<Character_Movie>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.MovieId });

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Character_Movies)
                    .HasForeignKey(d => d.CharacterId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Character_Movies)
                    .HasForeignKey(d => d.MovieId);
            });

        }



    }
}
