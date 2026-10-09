using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoviesTVShows.Model;

namespace MoviesTVShows.Repository;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>{entity.HasKey(e => e.Id).HasName("genres_pkey");
            entity.ToTable("genres");
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
        });

        modelBuilder.Entity<Movie>(entity =>{
            entity.HasKey(e => e.Id).HasName("movies_pkey");
            entity.ToTable("movies");
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
            entity.Property(e => e.Durationmin).HasColumnName("durationmin");
            entity.Property(e => e.Genreid).HasColumnName("genreid");
            entity.Property(e => e.Rating).HasPrecision(3, 1).HasColumnName("rating");
            entity.Property(e => e.Title).HasMaxLength(50).HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.HasOne(d => d.Genre).WithMany(p => p.Movies).HasForeignKey(d => d.Genreid).HasConstraintName("fk_movies_genres");
        });

        modelBuilder.Entity<User>(entity =>{ 
            entity.HasKey(e => e.Id).HasName("users_pkey");
            entity.ToTable("users");
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(50).HasColumnName("email");
            entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");
            entity.Property(e => e.Role).HasMaxLength(50).HasDefaultValueSql("'user'::character varying").HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
