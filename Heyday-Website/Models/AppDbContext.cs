using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置article的title为不重复
            modelBuilder.Entity<Article>()
                .HasIndex(a => a.Title)
                .IsUnique();
            //初始化文章类别
            Category[] categories = new Category[3]
            {
                new Category{Id = Guid.NewGuid(),CategoryName="intro"},
                new Category{Id = Guid.NewGuid(),CategoryName="activity"},
                new Category{Id = Guid.NewGuid(),CategoryName="others"},
            };

            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
