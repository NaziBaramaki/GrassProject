using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GrassShopDbContext : DbContext
    {
        public GrassShopDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Users> user => Set<Users>();
        public DbSet<Banners> Banners => Set<Banners>();
        public DbSet<GrassType> GrassType => Set<GrassType>();
        public DbSet<News> News => Set<News>();
        public DbSet<Requests> Requests => Set<Requests>();


           
    }
}

