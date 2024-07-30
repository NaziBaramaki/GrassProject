using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GrassShopDbContext : IdentityDbContext<Users>
    {
        public GrassShopDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Users> user => Set<Users>();
        public DbSet<Banners> Banners => Set<Banners>();
        public DbSet<GrassType> GrassType => Set<GrassType>();
        public DbSet<News> News => Set<News>();
        public DbSet<Requests> Requests => Set<Requests>();


        //protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Users>()
        //    //    .HasKey(a => a.Id);

        //    //modelBuilder.Entity<News>()
        //    //    .HasKey(b => b.Id)
        //    //    .HasRequired(b => b.Users)
        //    //    .WithMany(a => a.NewsId)
        //    //    .HasForeignKey(b => b.Users);

        //    modelBuilder.Entity<Users>()
        //    .HasMany(u => u.News)
        //    .WithOne(n => n.Users)
        //    .HasForeignKey(n => n.userId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //}

    }
}

