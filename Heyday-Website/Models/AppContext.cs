using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppContext(DbContextOptions<AppContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置article的title为不重复
            modelBuilder.Entity<Article>()
                .HasIndex(a => a.Title)
                .IsUnique();
        }
    }
}
